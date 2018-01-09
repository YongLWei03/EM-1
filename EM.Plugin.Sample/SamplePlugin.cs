using Common.Logging;
using EM.Common.Client;
using EM.Common.Plugin;
using System;

namespace EM.Plugin.Sample
{

  public class SamplePlugin : MarshalByRefObject, IPlugin
  {
    private ILog logger = LogManager.GetLogger<SamplePlugin>();

    public PropertyDictionary Properties { get; set; }

    public void Run()
    {
      logger.Debug("SamplePlugin running ...");
    }


  }
}
