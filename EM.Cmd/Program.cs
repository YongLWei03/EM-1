using Common.Logging;
using EM.Common.Client.Runtime;
using EM.Common.Utils;
using EM.Factory;
using System;
using System.Threading;

namespace EM.Cmd
{
  class Program
  {
    private static IIoCFactory iocFactory = new StructuredMapIoCFactory();

    static void Main(string[] args)
    {
      ILog logger = LogManager.GetLogger<Program>();

      logger.Info("Starting EM");

      IClientRuntimeManager initRuntime = iocFactory.GetInstance<IClientRuntimeManager>("Init");

      bool keepingRunning = true;
      while (keepingRunning)
      {

        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo key = Console.ReadKey(true);
          switch (key.Key)
          {
            case ConsoleKey.Escape:
              keepingRunning = false;
              break;
          }
        }

        initRuntime.Manage();

        Thread.Sleep(5000);
      }
      initRuntime.Stop();
    }

  }
}
