using Common.Logging;
using EM.Client.Template;
using EM.Common.Client;
using EM.Common.Client.Runtime;
using EM.Common.Plugin;

namespace EM.Client
{
  public class DefaultClient : DefaultClientTemplate, IClient
  {
    private ILog logger = LogManager.GetLogger<DefaultClient>();

    private IPlugin plugin = null;
    private ClientProperties properties = new ClientProperties();
    private ClientRuntimeProperties runtimeProperties = new ClientRuntimeProperties();
    private bool running = false;

    public DefaultClient() : base()
    {
      RuntimeProperties = new ClientRuntimeProperties();
    }

    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientRuntimeProperties RuntimeProperties { get => runtimeProperties; set => runtimeProperties = value; }
    public bool Running
    {
      get { return running; }
      set { running = value; }

    }
  }
}
