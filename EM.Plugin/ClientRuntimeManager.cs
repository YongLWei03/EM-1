using EM.Common.Client;
using EM.Common.Client.Repository;
using EM.Common.Client.Runtime;
using EM.Common.Utils;
using System;
using System.Threading.Tasks;

namespace EM.Plugin
{
  public class ClientRuntimeManager : IClientRuntimeManager
  {
    private LimitedConcurrencyLevelTaskScheduler lcts = null;
    private TaskFactory factory = null;
    private IClientRepository clientRepository = null;

    public ClientRuntimeManager(IClientRepository clientRepository)
    {
      lcts = new LimitedConcurrencyLevelTaskScheduler(5);
      factory = new TaskFactory(lcts);
      this.clientRepository = clientRepository;
    }

    public void Manage(IClient client)
    {
      if (IsRunning(client))
      {
        client.Status.LastLifeSign = DateTime.Now;
        UpdateClientStatus(client);

        if (CheckIfClientMustStop(client))
        {
          Stop(client);
        }
      }
      else if (CheckIfClientMustRun(client))
      {
        Task clientTask = factory.StartNew(() => client.Start());
        client.RuntimeProperties.Task = clientTask;
        client.Status.LastRun = DateTime.Now;
        UpdateClientStatus(client);
      }
    }

    public void Stop(IClient client)
    {
      if (client.Running)
      {
        client.Stop();
      }
    }

    private void UpdateClientStatus(IClient client)
    {
      clientRepository.Update(client);
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


  }
}
