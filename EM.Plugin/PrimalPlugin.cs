using EM.Common;
using EM.Common.Client;
using EM.Common.Plugin;
using System;

namespace EM.Plugin
{
  public class PrimalPlugin : MarshalByRefObject, IPlugin
  {
    public PropertyDictionary Properties { get; set; }

    public bool Running => false;

    public void Start()
    {
      //foreach (var client in clientRepo.Clients)
      //{
      //  if (!client.Running)
      //  {
      //    if (CheckIfClientMustRun(client))
      //    {
      //      Task clientTask = Task.Factory.StartNew(() => client.Run());
      //      client.RuntimeProperties.Task = clientTask;
      //    }
      //  }
      //}
    }

    public void Stop()
    {
      ////TODO list
      ////Monitor clients
      ////Restart clients
      ////Ping clients
      ////Receive heart beat
      ////Maintain status of each client (e.g. running, stopped, crashed) in e.g. db table.
      //foreach (var client in clientRepo.Clients)
      //{
      //  if (client.Running)
      //  {
      //    client.Stop();
      //  }
      //}
    }


    private static bool CheckIfClientMustRun(IClient client)
    {
      return true;
    }
  }
}
