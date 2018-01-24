using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Common.PluginTemplate;

namespace EM.API.Cmd.Model
{
  public class Plugin
  {
    public string FullClassName { get; set; }
    public string DLLName { get; set; }

    public static Plugin From(IPluginTemplate p)
    {
      Plugin n = new Plugin();

      n.FullClassName = p.FullClassName;
      n.DLLName = p.DLLName;

      return n;
    }
  }
}
