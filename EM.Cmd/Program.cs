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
      Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger<Program>();

      logger.Info("Starting EM");

      var tokenSource = new CancellationTokenSource();
      CancellationToken ct = tokenSource.Token;

      Task t = Task.Factory.StartNew(() =>
      {
        ct.ThrowIfCancellationRequested();

        while (true)
        {
          if (ct.IsCancellationRequested)
          {
            ct.ThrowIfCancellationRequested();
          }
          Thread.Sleep(5000);
        }
      }, ct);

      try
      {
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
