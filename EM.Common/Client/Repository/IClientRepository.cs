using EM.Common.Client.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Repository
{
  public interface IClientRepository
  {
    IClientTemplateRepository ClientTemplateRepository { get; set; }
    IList<string> ClientNames { get; }
    IEnumerable<IClient> Clients { get; }
    IClient this[string clientName] { get; }
    void RemoveClientsWithPluginType(Type t);
  }
}
