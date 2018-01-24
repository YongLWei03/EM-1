using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.PluginTemplate.Repository
{
  public interface IPluginTemplateRepository : IEnumerable<IPluginTemplate>
  {
    void Add(string name, IPluginTemplate pluginTemplate);

    IPluginTemplate this[string name]
    {
      get;
      set;
    }
  }
}
