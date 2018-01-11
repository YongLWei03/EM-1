using Common.Logging;
using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Repository;
using EM.Common.Plugin;
using System;

namespace EM.Plugin
{
  public class PrimalPlugin : MarshalByRefObject, IPlugin
  {
    private ILog logger = LogManager.GetLogger<PrimalPlugin>();

    public PropertyDictionary Properties { get; set; }
    public IClientRepository ClientRepository { get; set; }

    public bool Running => false;

    public void Start()
    {
      logger.Debug("ClientRepository= " + ClientRepository == null ? "NULL!!!" : "not null good");
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
