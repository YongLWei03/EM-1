using Common.Logging;
using EM.Common.Client;
using EM.Common.Plugin;
using System;

namespace EM.Client
{
  public class DefaultClient : IClient 
  {
    private AppDomain appDomain = null;
    private IPlugin plugin = null;
    private ClientProperties properties= new ClientProperties();
    private ILog logger = LogManager.GetLogger<DefaultClient>();
    private bool running = false;

    public AppDomain AppDomain { get => appDomain; set => appDomain = value; }
    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientProperties Properties { get => properties; set => properties = value; }

    public bool Running => running || plugin.Running;

    public void Run()
    {
      running = true;
      logger.Debug("Default client running ...");
      logger.Debug("Name= " + Properties.Name);
      plugin.Run();
      running = false;
    }

    public void Stop()
    {
      logger.Debug(Properties.Name + " stopping");
      plugin.Stop();
    }
  }
}
