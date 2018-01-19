using EM.Common.Client;
using EM.Common.Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class ClientEFRepository : IClientPersistor
  {
    public void ToggleEnable(string clientName, bool isEnabled)
    {
      using (var ctx = new Entities())
      {
        var clientDB = (from s in ctx.Clients
                        where s.Name == clientName
                        select s).FirstOrDefault();

        clientDB.Enabled = isEnabled;
        ctx.SaveChanges();
      }
    }

    public void Update(IClient client)
    {
      using (var ctx = new Entities())
      {
        var clientDB = (from s in ctx.Clients
                        where s.Name == client.Name
                        select s).FirstOrDefault();

        if (clientDB == null)
        {
          var n = ctx.Clients.Create();
          ctx.Clients.Attach(n);

          n.Name = client.Name;
          n.Enabled = client.IsEnabled;

          SetProperty(n, "Description", client.Properties.Description);
          SetProperty(n, "IsEnabled", client.Properties.IsEnabled);
          SetProperty(n, "Name", client.Properties.Name);

          foreach (var cp in client.Properties.Properties)
          {
            SetProperty(n, cp.Key, cp.Value);
          }

          n.ClientSchedule = new ClientSchedule()
          {
            Clients = new List<Client>() { n },
            RunContinuously = client.Schedule.IsRunContinuously,
            RunEverySeconds = client.Schedule.RunEverySeconds
          };

          n.PluginTemplate = new PluginTemplate()
          {
            DLLName = client.PluginTemplate.DLLName,
            FullClassName = client.PluginTemplate.FullClassName
          };

        }
        else
        {
          if (client.Status != null)
          {
            clientDB.Enabled = client.IsEnabled;

            SetProperty(clientDB, "Description", client.Properties.Description);
            SetProperty(clientDB, "IsEnabled", client.Properties.IsEnabled);
            SetProperty(clientDB, "Name", client.Properties.Name);

            foreach (var cp in client.Properties.Properties)
            {
              SetProperty(clientDB, cp.Key, cp.Value);
            }

            clientDB.ClientSchedule.RunContinuously = client.Schedule.IsRunContinuously;
            clientDB.ClientSchedule.RunEverySeconds = client.Schedule.RunEverySeconds;

            clientDB.PluginTemplate.DLLName = client.PluginTemplate.DLLName;
            clientDB.PluginTemplate.FullClassName = client.PluginTemplate.FullClassName;

            clientDB.ClientStatus.Add(new ClientStatu()
            {
              Client = clientDB,
              LastLifeSign = client.Status.LastLifeSign,
              LastRun = client.Status.LastRun,
              NextRun = client.Status.NextRun
            });
          }
        }

        ctx.SaveChanges();
      }
    }
    private void SetProperty(Client clientDB, string key, object value)
    {
      var cp = clientDB.ClientProperties.FirstOrDefault(x => x.Key == key);
      if (cp == null)
      {
        clientDB.ClientProperties.Add(new ClientProperty()
        {
          Client = clientDB,
          Key = key,
          Value = (value?? "").ToString()
        });
      }
      else
      {
        cp.Value = value.ToString();
      }
    }

  }
}
