using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Repository
{
  public interface IClientRepository
  {
    IList<string> ClientNames { get; }
    IEnumerable<IClient> Clients { get; }
    IClient this[string clientName] { get; }
  }
}
