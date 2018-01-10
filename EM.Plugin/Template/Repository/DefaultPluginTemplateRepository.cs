using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System.Collections.Generic;

namespace EM.Plugin.Template.Repository
{
  public class DefaultPluginTemplateRepository : IPluginTemplateRepository
  {
    private Dictionary<string, IPluginTemplate> templates = new Dictionary<string, IPluginTemplate>();

    public void Add(string name, IPluginTemplate template)
    {
      templates.Add(name, template);
    }

    public IPluginTemplate this[string name]
    {
      get { return templates[name]; }
      set { templates[name] = value; }
    }
  }
}
