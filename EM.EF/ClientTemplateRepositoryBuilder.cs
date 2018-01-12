using EM.Client.Template;
using EM.Client.Template.Repository;
using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class ClientTemplateRepositoryBuilder : IClientTemplateRepositoryBuilder
  {
    public IClientTemplateRepository Build(IPluginTemplateRepository pluginTemplates)
    {
      IClientTemplateRepository repo = new DefaultClientTemplateRepository();
      using (var ctx = new Entities())
      {
        var query = from c in ctx.Clients
                    select c;

        foreach (var client in query)
        {
          repo.Add(client.Name, new DefaultClientTemplate()
          {
            Name = client.Name,
            PluginTemplate = pluginTemplates[client.PluginTemplate.FullClassName],
            Properties = GetProperties(client.ClientProperties),
            Schedule = GetSchedule(client.ClientSchedule),
            Status = GetStatus(client.ClientStatus)
          });
        }
      }
      return repo;
    }

    private ClientStatus GetStatus(ICollection<ClientStatu> clientStatus)
    {
      ClientStatus status = new ClientStatus();
      var latest = clientStatus.OrderByDescending(x => x.LastRun).FirstOrDefault();
      if (latest != null)
      {
        status.LastRun = latest.LastRun;
      }
      return status;
    }

    private Common.Client.ClientSchedule GetSchedule(ClientSchedule clientSchedule)
    {
      Common.Client.ClientSchedule schedule = new Common.Client.ClientSchedule()
      {
        IsRunContinuously = clientSchedule.RunContinuously,
        RunEverySeconds = clientSchedule.RunEverySeconds
      };
      return schedule;
    }

    private PropertyDictionary GetProperties(ICollection<ClientProperty> clientProperties)
    {
      PropertyDictionary pd = new PropertyDictionary();
      foreach (var cp in clientProperties)
      {
        pd.Add(cp.Key, cp.Value);
      }
      return pd;
    }
  }
}
