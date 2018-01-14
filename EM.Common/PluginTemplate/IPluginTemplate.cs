using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.PluginTemplate
{
  public interface IPluginTemplate
  {
    string DLLName { get; set; }
    string FullClassName { get; set; }
    Type PluginType { get; }
  }
}
