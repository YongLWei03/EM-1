﻿using Common.Logging;
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
    private bool running = false;
    private bool stopRequested = false;

    public PropertyDictionary Properties { get; set; }

    private bool StopRequested
    {
      get
      {       
          return stopRequested;
      }
      set
      {
        lock(this) {
          stopRequested = value;
        }
      }
    }

    public bool Running => running;

    public void Run()
    {
      running = true;
      while (!StopRequested)
      {
        logger.Debug("Hello from SamplePluginForever");
        Thread.Sleep(5000);
      }
      running = false;
    }

    public void Stop()
    {
      logger.Debug("plugin stopping " + Thread.CurrentThread.Name);
      StopRequested = true;
    }
  }
}