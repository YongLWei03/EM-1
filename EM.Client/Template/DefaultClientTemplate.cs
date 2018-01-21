using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Template;
using EM.Common.PluginTemplate;
using EM.Plugin.Template;

namespace EM.Client.Template
{
  public class DefaultClientTemplate : IClientTemplate
  {
    public DefaultClientTemplate()
    {
      Properties = new ClientProperties();
      Schedule = new ClientSchedule();
      Status = new ClientStatus();
      PluginTemplate = new DefaultPluginTemplate();
    }

    public string Name { get => Properties.Name; set => Properties.Name = value; }
    public bool IsEnabled { get => Properties.IsEnabled; set => Properties.IsEnabled = value; }
    public IPluginTemplate PluginTemplate { get; set; }
    public ClientProperties Properties { get; set; }
    public ClientSchedule Schedule { get; set; }
    public ClientStatus Status { get; set; }
  }
}
