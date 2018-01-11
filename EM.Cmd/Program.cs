using Common.Logging;
using EM.Client.Factory;
using EM.Client.Repository;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using EM.EF;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EM.Cmd
{
  class Program
  {
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
          client.Start();
        }

        Thread.Sleep(5000);
      }

      client.Stop();

    }


    private static IClient GetPrimalClient()
    {
      var repo = BuildClientRepository();
      return repo["Primal Client"];
    }

    private static IClientRepository BuildClientRepository()
    {
      //TODO Use IoC, move out of here
      PluginTemplateRepositoryBuilder pluginBuilder = new PluginTemplateRepositoryBuilder();
      IPluginTemplateRepository pluginRepo = pluginBuilder.Build();
      ClientTemplateRepositoryBuilder clientBuilder = new ClientTemplateRepositoryBuilder();
      IClientTemplateRepository clientTemplateRepo = clientBuilder.Build(pluginRepo);
      IFactory clientFactory = new DefaultClientFactory();
      IClientRepository clientRepo = new DefaultClientRepository() { ClientFactory = clientFactory, ClientTemplateRepository = clientTemplateRepo };
      return clientRepo;
    }
  }
}
