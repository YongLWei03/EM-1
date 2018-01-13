using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.Client.Repository
{
  [Serializable]
  public class DefaultClientRepository : IClientRepository
  {
    private IClientTemplateRepositoryBuilder clientTemplateRepositoryBuilder;
    private Dictionary<string, IClient> clients = new Dictionary<string, IClient>();

    public DefaultClientRepository(IClientTemplateRepositoryBuilder clientTemplateRepositoryBuilder)
      => this.clientTemplateRepositoryBuilder = clientTemplateRepositoryBuilder;

    private IClientFactory ClientFactory { get; set; }

    private IEnumerable<IClientTemplate> ClientTemplates
    {
      get
      {
        IClientTemplateRepository clientTemplateRepository = clientTemplateRepositoryBuilder.Build();
        return clientTemplateRepository.ClientTemplates;
      }
    }

    public IEnumerable<IClient> Clients
    {
      get
      {
        foreach (IClientTemplate template in ClientTemplates)
        {
          CreateOrUpdate(template.Name);
        }
        return clients.Values.AsEnumerable();
      }
    }

    public IClient this[string clientName]
    {
      get
      {
        CreateOrUpdate(clientName);
        return clients[clientName];
      }
    }

    private void CreateOrUpdate(String clientName)
    {
      var template = clientTemplateRepositoryBuilder.Build(clientName);

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

    private bool IsNewClientRequired(IClientTemplate template)
    {
      return !IsClientExists(template) || IsPluginChanged(template);
    }

    private bool IsClientExists(IClientTemplate template)
    {
      return clients.ContainsKey(template.Name);
    }

    private bool IsClientExists(string clientName)
    {
      return clients.ContainsKey(clientName);
    }

    private bool IsPluginChanged(IClientTemplate template)
    {
      return clients[template.Name].Plugin.GetType() != template.PluginTemplate.PluginType;
    }

    private void TryStopAndRemove(string name)
    {
      if (IsClientExists(name))
      {
        clients[name].Stop();
        clients[name] = null;
        clients.Remove(name);
      }
    }

    private void Merge(IClient client, IClientTemplate ct)
    {
      client.Plugin.Properties = ct.Properties.Properties.Clone();
      client.Properties = ct.Properties.Clone();
      client.Schedule = ct.Schedule.Clone();
    }

    private void MakeAndAddNew(IClientTemplate template)
    {
      clients.Add(template.Name, ClientFactory.MakeClient(template));
    }
  }
}
