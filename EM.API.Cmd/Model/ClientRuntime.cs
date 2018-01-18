using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.API.Cmd.Model
{
  public class ClientRuntime
  {
    public DateTime LastRun { get; set; }
    public DateTime LastLifeSign { get; set; }
    public DateTime NextRun { get; set; }
  }
}
