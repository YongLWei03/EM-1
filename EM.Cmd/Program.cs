﻿using Common.Logging;
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

      IPluginTemplateRepositoryBuilder pluginBuilder = iocFactory.GetInstance<IPluginTemplateRepositoryBuilder>();// new PluginTemplateRepositoryBuilder();
      IPluginTemplateRepository pluginRepo = pluginBuilder.Build();
      IClientTemplateRepositoryBuilder clientBuilder = iocFactory.GetInstance<IClientTemplateRepositoryBuilder>();// new ClientTemplateRepositoryBuilder();
      IClientTemplateRepository clientTemplateRepo = clientBuilder.Build(pluginRepo);
      IClientFactory clientFactory = iocFactory.GetInstance<IClientFactory>();// new DefaultClientFactory();
      IClientRepository clientRepo = iocFactory.GetInstance<IClientRepository>();// new DefaultClientRepository() { ClientFactory = clientFactory, ClientTemplateRepository = clientTemplateRepo };
      return clientRepo;
    }
  }
}
