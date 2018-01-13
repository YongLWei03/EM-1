using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Runtime
{
  public interface IClientRuntimeManager
  {
    void Manage(IClient client);
    void Stop(IClient client);
  }
}
