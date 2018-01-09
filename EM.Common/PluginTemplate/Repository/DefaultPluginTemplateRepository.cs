using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.PluginTemplate.Repository
{
  public class DefaultPluginTemplateRepository : IPluginTemplateRepository
  {
    private Dictionary<string, IPluginTemplate> templates = new Dictionary<string, IPluginTemplate>();

    public void Add(string name, IPluginTemplate template)
    {
      templates.Add(name, template);
    }

    public IPluginTemplate Get(string name)
    {
      return templates[name];
    }
  }
}
