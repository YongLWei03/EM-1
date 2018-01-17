using Common.Logging;
using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Repository;
using EM.Common.Client.Runtime;
using EM.Common.Plugin;
using System;
using System.Threading;

namespace EM.Plugin
{
  public class PrimalPlugin : MarshalByRefObject, IPlugin
  {
    private ILog logger = LogManager.GetLogger<PrimalPlugin>();
 
    public PropertyDictionary Properties { get; set; }
    //public IClientRepository ClientRepository { get; set; }
    public IClientRuntimeManager RuntimeManager { get; set; }

    public bool Running { get; private set; }

    public void Start()
    {
      Running = true;
      while (Running)
      {
        RuntimeManager.Manage();        
        Thread.Sleep(5000);
      }


    }

    public void Stop()
    {
      Running = false;
      ////TODO list
      ////Monitor clients
      ////Restart clients
      ////Ping clients
      ////Receive heart beat
      ////Maintain status of each client (e.g. running, stopped, crashed) in e.g. db table.
      //foreach (var client in ClientRepository.Clients)
      //{
      //  RuntimeManager.Stop(client);
      //}

      //ClientRepository = null;
      RuntimeManager.Stop();
      RuntimeManager = null;
    }

  }
}
