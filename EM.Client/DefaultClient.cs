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

    public AppDomain AppDomain { get => appDomain; set => appDomain = value; }
    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientProperties Properties { get => properties; set => properties = value; }

    public void Run()
    {
      logger.Debug("Default client running ....");
      plugin.Run();
    }
  }
}
