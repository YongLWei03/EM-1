using Common.Logging;
using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Client.Sample
{
  [System.Obsolete]
  public class SampleClient : IClient //TODO Rename to default (and namespace).
  {
    private AppDomain appDomain;
    private IPlugin plugin;
    private ILog logger = LogManager.GetLogger<SampleClient>();

    public SampleClient(AppDomain appDomain, IPlugin plugin)
    {
      this.appDomain = appDomain;
      this.plugin = plugin;
    }

    public IPlugin Plugin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ClientProperties Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Run()
    {
      logger.Debug("Sample client running ....");
      plugin.Run();
    }
  }
}
