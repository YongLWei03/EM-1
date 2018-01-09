using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System.Collections.Generic;

namespace EM.Repository.Sample
{
  public class SampleTemplateRepository : IPluginTemplateRepository
  {
    private Dictionary<string, IPluginTemplate> templates = new Dictionary<string, IPluginTemplate>()
    {
      { "EM.Plugin.Sample.SamplePlugin", new DefaultPluginTemplate("EM.Plugin.Sample.dll", "EM.Plugin.Sample.SamplePlugin")}
    };

    public IPluginTemplate Get(string name) //TODO Use []-operator
    {
      return templates[name];
    }
  }
}
