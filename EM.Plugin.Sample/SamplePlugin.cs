using Common.Logging;
using EM.Common;
using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Threading;

namespace EM.Plugin.Sample
{

  public class SamplePlugin : MarshalByRefObject, IPlugin
  {
    private ILog logger = LogManager.GetLogger<SamplePlugin>();
    private bool running = false;

    public PropertyDictionary Properties { get; set; }

    public bool Running => running;

    public void Run()
    {
      running = true;
      logger.Debug("SamplePlugin running ...");
      running = false;
    }

    public void Stop()
    {
      //NA
      logger.Debug("plugin stopping " + Thread.CurrentThread.Name);
    }
  }
}
