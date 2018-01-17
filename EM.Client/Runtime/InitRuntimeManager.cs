using Common.Logging;
using EM.Client.Repository;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Runtime;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using EM.Common.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Client.Runtime
{
  public class InitRuntimeManager : ClientRuntimeManager, IClientRuntimeManager
  {
    public InitRuntimeManager(IClientFactory clientFactory, IClientPersistor clientPersistor, IClientTemplateRepositoryBuilder builder) : base(clientFactory, clientPersistor, builder)
    {
    }

    protected override bool CheckIfClientMustRun(IClient client)
    {
      return
         (
        client.Schedule.IsRunContinuously ||
        client.Status.LastRun.AddSeconds(client.Schedule.RunEverySeconds) < DateTime.Now);
    }

   
  }
}
