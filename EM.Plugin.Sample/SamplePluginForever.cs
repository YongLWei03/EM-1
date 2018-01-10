using Common.Logging;
using EM.Common;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EM.Plugin.Sample
{
  public class SamplePluginForever : IPlugin
  {
    private ILog logger = LogManager.GetLogger<SamplePluginForever>();
    public PropertyDictionary Properties { get; set; }

    public void Run()
    {
      while (true)
      {
        logger.Debug("Hello from SamplePluginForever");
        Thread.Sleep(5000);
      }
    }
  }
}
