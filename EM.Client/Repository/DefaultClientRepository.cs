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

    public IClientFactory ClientFactory { get; set; }
 
    //public IList<string> ClientNames => ClientTemplates.ClientNames;

    public IEnumerable<IClientTemplate> ClientTemplates
    {
      get
      {
        IClientTemplateRepository clientTemplateRepository  = clientTemplateRepositoryBuilder.Build();
        return clientTemplateRepository.ClientTemplates;
      }
    }

    public IEnumerable<IClient> Clients
    {
      get
      {
        return null;
        //foreach (var cn in ClientNames)
        //{
        //  yield return this[cn];
        //}
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
