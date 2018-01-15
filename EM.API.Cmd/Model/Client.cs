using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.API.Cmd.Model
{
  public class Client
  {
    public string Name { get; set; }
    public string PluginType { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime LastRun { get; set; }
    public DateTime LastLifeSign { get; set; }
  }
}
