using EM.Common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugin
{
  public class ClientRuntimeManager //TODO Make interface
  {
    public void Manage(IClient client)
    {
      if (!IsRunning(client))
      {
        if (CheckIfClientMustRun(client))
        {
          Task clientTask = Task.Factory.StartNew(() => client.Start());
          client.RuntimeProperties.Task = clientTask;
        }
      }

    }

    public void Stop(IClient client)
    {
      if (client.Running)
      {
        client.Stop();
      }
    }

    private static bool CheckIfClientMustRun(IClient client)
    {
      return client.Properties.IsRunContinuously ||
        client.RuntimeProperties.LastRun.AddSeconds(client.Properties.RunEverySeconds) < DateTime.Now;
    }

    private bool IsRunning(IClient client)
    {
      var t = client.RuntimeProperties.Task;
      return t != null
        && (t.Status == TaskStatus.Running || t.Status == TaskStatus.Created || t.Status == TaskStatus.WaitingForActivation || t.Status == TaskStatus.WaitingForChildrenToComplete || t.Status == TaskStatus.WaitingToRun)
        && (client.Running || client.Plugin.Running);
    }


  }
}
