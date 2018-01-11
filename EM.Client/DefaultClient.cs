using Common.Logging;
using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Threading.Tasks;

namespace EM.Client
{
  public class DefaultClient : IClient
  {
    private AppDomain appDomain = null;
    private IPlugin plugin = null;
    private ClientProperties properties = new ClientProperties();
    private ClientRuntimeProperties runtimeProperties = new ClientRuntimeProperties();
    private ILog logger = LogManager.GetLogger<DefaultClient>();
    private bool running = false;

    public AppDomain AppDomain { get => appDomain; set => appDomain = value; }
    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientProperties Properties { get => properties; set => properties = value; }
    public ClientRuntimeProperties RuntimeProperties { get => runtimeProperties; set => runtimeProperties = value; }
    public bool Running => DetermineIfRunning();

    public void Start()
    {
      running = true;
      logger.Debug("Default client running ...");
      logger.Debug("Name= " + Properties.Name);
      plugin.Start();
      running = false;
    }

    public void Stop()
    {
      logger.Debug(Properties.Name + " stopping");
      plugin.Stop();
    }

    private bool DetermineIfRunning()
    {
      var t = runtimeProperties.Task;
      return t != null
        && (t.Status == TaskStatus.Running || t.Status == TaskStatus.Created || t.Status == TaskStatus.WaitingForActivation || t.Status == TaskStatus.WaitingForChildrenToComplete || t.Status == TaskStatus.WaitingToRun)
        && (running || plugin.Running);
    }
  }
}
