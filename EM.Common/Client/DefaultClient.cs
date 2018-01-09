using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using EM.Common.Plugin;

namespace EM.Common.Client
{
  public class DefaultClient : IClient //TODO Move out of common.
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
