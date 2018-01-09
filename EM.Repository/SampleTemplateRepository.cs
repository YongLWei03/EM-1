using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System.Collections.Generic;

namespace EM.Repository.Sample
{
  public class SampleTemplateRepository : ITemplateRepository
  {
    private Dictionary<string, ITemplate> templates = new Dictionary<string, ITemplate>()
    {
      { "EM.Plugin.Sample.SamplePlugin", new DefaultTemplate("EM.Plugin.Sample.dll", "EM.Plugin.Sample.SamplePlugin")}
    };

    public ITemplate Get(string name)
    {
      return templates[name];
    }
  }
}
