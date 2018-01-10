using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.PluginTemplate.Repository
{
  public interface IPluginTemplateRepository
  {
    void Add(string name, IPluginTemplate pluginTemplate);

    IPluginTemplate this[string name]
    {
      get;
      set;
    }
  }
}
