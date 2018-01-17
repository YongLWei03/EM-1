using Common.Logging;
using EM.Common.Client;
using EM.Common.Client.Runtime;
using EM.Common.Plugin;

namespace EM.Client
{
  public class DefaultClient : IClient
  {
    private ILog logger = LogManager.GetLogger<DefaultClient>();

    private IPlugin plugin = null;
    private ClientProperties properties = new ClientProperties();
    private ClientRuntimeProperties runtimeProperties = new ClientRuntimeProperties();
    private bool running = false;

    public DefaultClient()
    {
      Properties = new ClientProperties();
      RuntimeProperties = new ClientRuntimeProperties();
      Schedule = new ClientSchedule();
      Status = new ClientStatus();
    }

    public string Name { get => Properties.Name; set => Properties.Name = value; }
    public bool IsEnabled { get => Properties.IsEnabled; set => Properties.IsEnabled = value; }

    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientProperties Properties { get => properties; set => properties = value; }
    public ClientRuntimeProperties RuntimeProperties { get => runtimeProperties; set => runtimeProperties = value; }
    public ClientSchedule Schedule { get; set; }
    public ClientStatus Status { get; set; }
    public bool Running
    {
      get { return running; }
      set { running = value; }

    }
  }
}
