using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using EM.Common.Plugin;

namespace EM.Common.Client
{
  public class DefaultClient : IClient
  {
    private AppDomain appDomain;
    private IPlugin plugin;
    private ClientProperties properties;
    private ILog logger = LogManager.GetLogger<DefaultClient>();

    public DefaultClient(AppDomain appDomain, IPlugin plugin)
    {
      this.appDomain = appDomain;
      this.plugin = plugin;
    }

    public IPlugin Plugin { get => plugin; set => plugin = value; }
    public ClientProperties Properties { get => properties; set => properties = value; }

    public void Run()
    {
      logger.Debug("Default client running ....");
      plugin.Run();
    }
  }
}
