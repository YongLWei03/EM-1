using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Client.Sample
{
  public class SampleClient : IClient
  {
    private AppDomain appDomain;
    private IPlugin plugin;

    public SampleClient(AppDomain appDomain, IPlugin plugin)
    {
      this.appDomain = appDomain;
      this.plugin = plugin;
    }

    public void Run()
    {
      plugin.Run();
    }
  }
}
