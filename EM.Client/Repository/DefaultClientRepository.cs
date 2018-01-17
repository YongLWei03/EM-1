using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EM.Client.Repository
{
  [Serializable]
  public class DefaultClientRepository : IClientRepository
  {
    //private IClientFactory clientFactory;
    //private IClientTemplateRepositoryBuilder clientTemplateRepositoryBuilder;
   // private IClientPersistor clientPersistor;
    private Dictionary<string, IClient> clients = new Dictionary<string, IClient>();

    //public DefaultClientRepository(IClientPersistor clientPersistor)
    // // IClientTemplateRepositoryBuilder clientTemplateRepositoryBuilder, IClientPersistor clientPersistor)
    // // => (this.clientTemplateRepositoryBuilder, this.clientPersistor) = (clientTemplateRepositoryBuilder, clientPersistor);
    // => this.clientPersistor = clientPersistor;



    //public IEnumerable<IClientTemplate> ClientTemplates
    //{
    //  get
    //  {
    //    IClientTemplateRepository clientTemplateRepository = clientTemplateRepositoryBuilder.Build();
    //    return clientTemplateRepository.ClientTemplates;
    //  }
    //}

    public IEnumerable<IClient> Clients
    {
      get
      {
        //Dictionary<string, IClient> clients = new Dictionary<string, IClient>();
        //var templates = ClientTemplates;
        //foreach (IClientTemplate template in templates)
        //{
        //  clients.Add(template.Name, Create(template));
        //}
        return clients.Values.AsEnumerable();
      }
    }

    public IClient this[string clientName]
    {
      get
      {
        //var template = clientTemplateRepositoryBuilder.Build(clientName);
        //return Create(template);
        return clients[clientName];
      }
      set
      {
        clients[clientName] = value;
      }
    }

    //public void Update(IClient client)
    //{
    //  clientPersistor.Update(client);
    //}

    public void Add(string name, IClient client)
    {
      clients.Add(name, client);
    }

    public IEnumerator<IClient> GetEnumerator()
    {
      return ReturnEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ReturnEnumerator();
    }

    private IEnumerator<IClient> ReturnEnumerator()
    {
      return clients.Values.GetEnumerator();
    }

    public bool ContainsClientWithName(string clientName)
    {
      return clients.ContainsKey(clientName);
    }

    public void Remove(IClient client)
    {
      clients[client.Name] = null;
      clients.Remove(client.Name);
    }


    //private IClient Create(IClientTemplate template)
    //{
    //  return clientFactory.MakeClient(template);
    //}

    //private void CreateOrUpdate(IClientTemplate template)
    //{

    //  if (IsNewClientRequired(template))
    //  {
    //    TryStopAndRemove(template.Name);
    //    MakeAndAddNew(template);
    //  }
    //  else
    //  {
    //    Merge(clients[template.Name], template);
    //  }
    //}

    //private bool IsNewClientRequired(IClientTemplate template)
    //{
    //  return !IsClientExists(template) || IsPluginChanged(template);
    //}

    //private bool IsClientExists(IClientTemplate template)
    //{
    //  return clients.ContainsKey(template.Name);
    //}

    //private bool IsClientExists(string clientName)
    //{
    //  return clients.ContainsKey(clientName);
    //}

    //private bool IsPluginChanged(IClientTemplate template)
    //{
    //  return clients[template.Name].Plugin.GetType() != template.PluginTemplate.PluginType;
    //}

    //private void TryStopAndRemove(string name)
    //{
    //  if (IsClientExists(name))
    //  {
    //    clients[name].Stop();
    //    clients[name] = null;
    //    clients.Remove(name);
    //  }
    //}

    //private void Merge(IClient client, IClientTemplate ct)
    //{
    //  client.Plugin.Properties = ct.Properties.Properties.Clone();
    //  client.Properties = ct.Properties.Clone();
    //  client.Schedule = ct.Schedule.Clone();
    //}

    //private void MakeAndAddNew(IClientTemplate template)
    //{
    //  clients.Add(template.Name, clientFactory.MakeClient(template));
    //}

  }
}
