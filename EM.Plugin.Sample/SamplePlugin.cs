using Common.Logging;
using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugin.Sample
{

  public class SamplePlugin : MarshalByRefObject, IPlugin
  {
    private ILog logger = LogManager.GetLogger<SamplePlugin>();

    public void Run()
    {
      logger.Debug("SamplePlugin running ...");
    }

   
  }
}
