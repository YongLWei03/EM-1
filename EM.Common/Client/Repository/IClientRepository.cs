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
    IEnumerable<IClient> Clients { get; }
    IClient this[string clientName] { get; }
  }
}
