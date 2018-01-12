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
    private ClientRuntimeManager runtime = new ClientRuntimeManager(); //TODO Use IoC and use the interface

    public PropertyDictionary Properties { get; set; }
    public IClientRepository ClientRepository { get; set; }

    public bool Running => false;

    public void Start()
    {
      logger.Debug("ClientRepository= " + ClientRepository == null ? "NULL!!!" : "not null good");

      RemoveSelfFromClientRepository();

      foreach (IClient client in ClientRepository.Clients)
      {
        runtime.Manage(client);
      }


    }

    public void Stop()
    {
      ////TODO list
      ////Monitor clients
      ////Restart clients
      ////Ping clients
      ////Receive heart beat
      ////Maintain status of each client (e.g. running, stopped, crashed) in e.g. db table.
      foreach (var client in ClientRepository.Clients)
      {
        runtime.Stop(client);
      }
    }

    private void RemoveSelfFromClientRepository()
    {
      ClientRepository.RemoveClientsWithPluginType(GetType());
    }

  }
}
