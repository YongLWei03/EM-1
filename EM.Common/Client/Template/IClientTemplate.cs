using EM.Common.Client;
using EM.Common.PluginTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Template
{
  public interface IClientTemplate
  {
    string Name { get; set; }
    IPluginTemplate PluginTemplate { get; set; }
    ClientProperties Properties { get; set; }
    ClientSchedule Schedule { get; set; }
    ClientStatus Status { get; set; }
  }
}
