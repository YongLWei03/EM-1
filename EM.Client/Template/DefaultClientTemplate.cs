using EM.Common.Client;
using EM.Common.Client.Template;
using EM.Common.PluginTemplate;

namespace EM.Client.Template
{
  public class DefaultClientTemplate : IClientTemplate
  {
    public string Name { get; set; }
    public IPluginTemplate PluginTemplate { get; set; }
    public PropertyDictionary Properties { get; set; }
  }
}
