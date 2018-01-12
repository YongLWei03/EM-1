using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.Client.Repository
{
  [Serializable]
  public class DefaultClientRepository : IClientRepository
  {
    private Dictionary<string, IClient> clients = new Dictionary<string, IClient>();

    public DefaultClientRepository()
    {

    }

    public IClientFactory ClientFactory { get; set; } 
    public IClientTemplateRepository ClientTemplateRepository { get; set; }

    public IList<string> ClientNames => ClientTemplateRepository.ClientNames;
    public IEnumerable<IClient> Clients
    {
      get
      {
        foreach (var cn in ClientNames)
        {
          yield return this[cn];
        }
      }
    }

    public IClient this[string clientName]
    {
      get
      {
        if (!clients.ContainsKey(clientName))
        {
          clients.Add(clientName, ClientFactory.MakeClient(ClientTemplateRepository[clientName]));
        }
        return clients[clientName];
      }
    }

    public void RemoveClientsWithPluginType(Type t)
    {
      foreach (var item in clients.Where(kvp => kvp.Value.Plugin.GetType() == t).ToList())
      {
        clients.Remove(item.Key);
      }
    }
  }
}
