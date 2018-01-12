using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientRuntimeProperties
  {
    public ClientRuntimeProperties()
    {
      LastRun = DateTime.MinValue;
    }

    public Task Task { get; set; }
    public DateTime LastRun { get; set; }
  }
}
