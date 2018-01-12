using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientStatus
  {
    public ClientStatus()
    {
      LastRun = DateTime.MinValue;
    }

    public DateTime LastRun { get; set; }
  }
}
