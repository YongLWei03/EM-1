using EM.Client.Factory;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using System.Collections.Generic;

namespace EM.Client.Repository
{
  public class DefaultClientRepository : IClientRepository
  {
    private Dictionary<string, IClient> clients = new Dictionary<string, IClient>();

    public DefaultClientRepository()
    {

    }

    public IFactory ClientFactory { get; set; } 
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
  }
}
