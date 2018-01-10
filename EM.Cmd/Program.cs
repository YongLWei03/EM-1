using Common.Logging;
using EM.Client.Repository;
using EM.Common.Client;
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

      var tokenSource = new CancellationTokenSource();
      CancellationToken ct = tokenSource.Token;

      Task t = Task.Factory.StartNew(() =>
      {
        logger.Debug("Task running...");

        ct.ThrowIfCancellationRequested();

        PluginTemplateRepositoryBuilder pluginBuilder = new PluginTemplateRepositoryBuilder();
        IPluginTemplateRepository pluginRepo = pluginBuilder.Build();
        ClientTemplateRepositoryBuilder clientBuilder = new ClientTemplateRepositoryBuilder();
        IClientTemplateRepository clientTemplateRepo = clientBuilder.Build(pluginRepo);
        IClientRepository clientRepo = new DefaultClientRepository() { ClientTemplateRepository = clientTemplateRepo };
        //IClient client = clientRepo["Sample Client"];

        while (true)
        {
          if (ct.IsCancellationRequested)
          {
            foreach (var client in clientRepo.Clients)
            {
              if (client.Running)
              {
                client.Stop();
              }
            }
            ct.ThrowIfCancellationRequested();
          }

          foreach (var client in clientRepo.Clients)
          {
            if (!client.Running)
            {
              client.Run();
            }
          }

          Thread.Sleep(5000);
        }
      }, ct);

      try
      {
        Thread.Sleep(15000);
        tokenSource.Cancel();
        logger.Info("Waiting for task to finish.");
        t.Wait();
      }
      catch (AggregateException e)
      {
        logger.Error(e.Message, e);
        foreach (var v in e.InnerExceptions)
        {
          logger.Error(v.Message, v);
        }
      }
      finally
      {
        tokenSource.Dispose();
      }
    }
  }
}
