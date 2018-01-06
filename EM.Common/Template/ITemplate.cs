using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Template
{
  public interface ITemplate
  {
    Type PluginType { get; }
  }
}
