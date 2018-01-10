using EM.Client.Factory;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.ClientTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Client.Repository
{
  public class DefaultClientRepository : IClientRepository
  {
    private IFactory factory = new DefaultClientFactory();

    public DefaultClientRepository()
    {

    }
    public IClientTemplateRepository ClientTemplateRepository { get; set; }
    public IClient this[string clientName] => factory.MakeClient(ClientTemplateRepository[clientName]);
  }
}
