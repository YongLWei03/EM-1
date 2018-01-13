using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Runtime
{
  public class ClientRuntimeProperties
  {
    public ClientRuntimeProperties()
    {
      Task = null;
    }

    public Task Task { get; set; }
  }
}
