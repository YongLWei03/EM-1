using EM.Common.Client.Runtime;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public interface IClient
  {
    string Name { get; set; }
    bool IsEnabled { get; set; }
    bool Running { get; set; }

    IPlugin Plugin { get; set; }
    ClientProperties Properties { get; set; }
    ClientSchedule Schedule { get; set; }
    ClientStatus Status { get; set; }

    ClientRuntimeProperties RuntimeProperties { get; set; }

  }
}
