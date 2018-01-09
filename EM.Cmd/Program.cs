using Common.Logging;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.ClientTemplate.Repository;
using EM.Common.PluginTemplate.Repository;
using EM.EF;
using EM.Factory.Sample;
using System;
using System.Data.Entity;
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

        Database.SetInitializer<EMContext>(new TemplateRepositoryInitializer());
        PluginTemplateRepositoryBuilder pluginBuilder = new PluginTemplateRepositoryBuilder();
        IPluginTemplateRepository  pluginRepo = pluginBuilder.Build();
        ClientTemplateRepositoryBuilder clientBuilder = new ClientTemplateRepositoryBuilder();
        IClientTemplateRepository clientTemplateRepo = clientBuilder.Build(pluginRepo);

        //ITemplateRepository repository = new SampleTemplateRepository();
        IFactory factory = new SampleFactory();
        IClient client = factory.MakeClient(clientTemplateRepo.Get("EM.Plugin.Sample.SamplePlugin"));

        while (true)
        {
          if (ct.IsCancellationRequested)
          {
            ct.ThrowIfCancellationRequested();
          }

          client.Run();

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
