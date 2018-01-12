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
    IPlugin Plugin { get; set; }
    ClientProperties Properties { get; set; }
    ClientSchedule Schedule { get; set; }
    ClientStatus Status { get; set; }
    ClientRuntimeProperties RuntimeProperties { get; set; }

    bool Running { get; }
    void Start();
    void Stop();
  }
}
