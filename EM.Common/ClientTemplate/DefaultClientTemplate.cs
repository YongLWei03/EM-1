using EM.Common.Client;
using EM.Common.PluginTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.ClientTemplate
{
  public class DefaultClientTemplate : IClientTemplate //TODO Move out of EM.Common
  {
    public string Name { get; set; }
    public IPluginTemplate PluginTemplate { get; set; }
    public PropertyDictionary Properties { get; set; }
  }
}
