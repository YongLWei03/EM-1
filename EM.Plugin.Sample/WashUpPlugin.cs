using Common.Logging;
using EM.Common;
using EM.Common.Client.Repository;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugin.Sample
{
  public class WashUpPlugin : IPlugin
  {
    private bool running = false;
    private ILog logger = LogManager.GetLogger<WashUpPlugin>();

    public PropertyDictionary Properties { get; set; } 
    public bool Running => running;
    public IWashUpRepository Repository { get; set; }

    public void Start()
    {
      running = true;
      logger.Debug("WashUp starting ...");
      Repository.RemoveOldStatus();
      running = false;
      logger.Debug("WashUp ended.");
    }

    public void Stop()
    {
      running = false;
      Repository = null;
    }
  }
}
