using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Plugin
{
  public interface ITemplate
  {
    Type PluginType { get; }
  }
}
