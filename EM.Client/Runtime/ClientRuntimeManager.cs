using Common.Logging;
using EM.Client.Repository;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Runtime;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using EM.Common.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Client.Runtime
{
  public class ClientRuntimeManager : IClientRuntimeManager
  {
    private IClientFactory clientFactory;
    private ILog logger = LogManager.GetLogger<ClientRuntimeManager>();
    private LimitedConcurrencyLevelTaskScheduler lcts = null;
    private TaskFactory factory = null;
    //private IClientTemplateRepository templateRepository = null;
    private IClientPersistor clientPersistor;
    private IClientTemplateRepositoryBuilder builder = null;
    private IClientRepository clients = null;
    //private Dictionary<string, IClient> clients = new Dictionary<string, IClient>();

    public ClientRuntimeManager(IClientFactory clientFactory, IClientPersistor clientPersistor, IClientTemplateRepositoryBuilder builder)
    {
      lcts = new LimitedConcurrencyLevelTaskScheduler(5);
      factory = new TaskFactory(lcts);
      this.clientFactory = clientFactory;
      this.builder = builder;
      this.clientPersistor = clientPersistor;
      clients = new DefaultClientRepository();
    }

    public void Manage() {

      var freshClientTemplates = builder.Build();
      foreach (IClientTemplate template in freshClientTemplates)
      {
        if (IsNewClientRequired(template))
        {
          TryStopAndRemove(template.Name);
          MakeAndAddNew(template);
        }
        else
        {
          Merge(clients[template.Name], template);
        }
      }

      foreach (IClient client in clients)
      {
        Manage(client);
      }
    }

    public void Stop()
    {
      foreach (var client in clients)
      {
        Stop(client);
      }

      clientFactory = null;
      clientPersistor = null;
      builder = null;
    }

    private bool IsNewClientRequired(IClientTemplate template)
    {
      return !IsClientExists(template) || IsPluginChanged(template);
    }

    private bool IsClientExists(IClientTemplate template)
    {
      return clients.ContainsClientWithName(template.Name);
    }

    private bool IsClientExists(string clientName)
    {
      return clients.ContainsClientWithName(clientName);
    }

    private bool IsPluginChanged(IClientTemplate template)
    {
      return clients[template.Name].Plugin.GetType() != template.PluginTemplate.PluginType;
    }

    private void TryStopAndRemove(string name)
    {
      if (IsClientExists(name))
      {
        Stop(clients[name]);
        clients.Remove(clients[name]);
      }
    }

    private void MakeAndAddNew(IClientTemplate template)
    {
      clients.Add(template.Name, clientFactory.MakeClient(template));
    }

    private void Merge(IClient client, IClientTemplate ct)
    {
      client.Plugin.Properties = ct.Properties.Properties.Clone();
      client.Properties = ct.Properties.Clone();
      client.Schedule = ct.Schedule.Clone();
    }

    private void Manage(IClient client)
    {
      if (IsRunning(client))
      {
        client.Status.LastLifeSign = DateTime.Now;
        client.Status.NextRun = DateTime.MinValue;
        if (CheckIfClientMustStop(client))
        {
          Stop(client);
          client.Status.NextRun = DateTime.Now.AddSeconds(client.Schedule.RunEverySeconds);
        }
      }
      else if (CheckIfClientMustRun(client))
      {
        Task clientTask = factory.StartNew(() => StartClient(client)); //use custom task factory when starting
        client.RuntimeProperties.Task = clientTask;
        client.Status.LastLifeSign = DateTime.Now;
        client.Status.LastRun = DateTime.Now;
        client.Status.NextRun = DateTime.MinValue;
      }
      else
      {
        client.Status.NextRun = client.Status.LastRun.AddSeconds(client.Schedule.RunEverySeconds);
      }

      UpdateClientStatus(client);
    }

    private void Stop(IClient client)
    {
      if (client.Running)
      {
        Task.Factory.StartNew(() => StopClient(client)); //Use default task factory when stopping.
      }
    }

    private void UpdateClientStatus(IClient client)
    {
      clientPersistor.Update(client);
    }

    private bool CheckIfClientMustStop(IClient client)
    {
      return !CheckIfClientMustRun(client);
    }

    private bool CheckIfClientMustRun(IClient client)
    {
      return
        client.Properties.IsEnabled && (
        client.Schedule.IsRunContinuously ||
        client.Status.LastRun.AddSeconds(client.Schedule.RunEverySeconds) < DateTime.Now);
    }

    private bool IsRunning(IClient client)
    {
      var t = client.RuntimeProperties.Task;

      return t != null
        && (t.Status == TaskStatus.Running || t.Status == TaskStatus.Created || t.Status == TaskStatus.WaitingForActivation || t.Status == TaskStatus.WaitingForChildrenToComplete || t.Status == TaskStatus.WaitingToRun)
        && (client.Running || client.Plugin.Running);
    }


    private void StartClient(IClient client)
    {
      client.Running = true;

      logger.Debug("Default client running ...");
      logger.Debug("Name= " + client.Properties.Name);

      client.Plugin.Start();
      client.Running = false;
    }

    private void StopClient(IClient client)
    {
      logger.Debug(client.Properties.Name + " stopping");
      client.Plugin.Stop();
      client.Running = false;
    }
  }
}
