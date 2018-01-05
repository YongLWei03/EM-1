using Common.Logging;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Plugin.Repository;
using EM.Factory.Sample;
using EM.Repository.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        IRepository repository = new SampleRepository();
        IFactory factory = new SampleFactory();
        IClient client = factory.MakeClient(repository.Get("EM.Plugin.Sample.SamplePlugin"));

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
        Thread.Sleep(5000);
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
