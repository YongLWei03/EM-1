using Common.Logging;
using EM.Client.Factory;
using EM.Client.Repository;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using EM.Common.Utils;
using EM.EF;
using EM.Factory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EM.Cmd
{
  class Program
  {
    private static IIoCFactory iocFactory = new StructuredMapIoCFactory();

    static void Main(string[] args)
    {
      ILog logger = LogManager.GetLogger<Program>();

      logger.Info("Starting EM");

      IClient client = GetPrimalClient();

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

        if (!client.Running)
        {
          Task t = Task.Factory.StartNew(() =>
          {
            client.Start();
          });

        }
        Thread.Sleep(5000);
      }
      client.Stop();
    }


    private static IClient GetPrimalClient()
    {
      var repo = BuildClientRepository();
      var client = repo["Primal Client"];
      return client;
    }

    private static IClientRepository BuildClientRepository()
    {
      return iocFactory.GetInstance<IClientRepository>();
    }
  }
}
