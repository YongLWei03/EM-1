using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System.Collections;
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

    public IEnumerator<IPluginTemplate> GetEnumerator()
    {
      return ReturnEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ReturnEnumerator();
    }

    public IPluginTemplate this[string name]
    {
      get { return templates[name]; }
      set { templates[name] = value; }
    }

    private IEnumerator<IPluginTemplate> ReturnEnumerator()
    {
      return templates.Values.GetEnumerator();
    }
  }
}
