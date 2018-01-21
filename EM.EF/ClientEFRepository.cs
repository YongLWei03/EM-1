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

    public void Delete(IClient client)
    {
      using (var ctx = new Entities())
      {
        var clientDB = (from s in ctx.Clients
                        where s.Name == client.Name
                        select s).FirstOrDefault();

        if (clientDB != null)
        {
          //clientDB.ClientProperties.Clear();
          clientDB.ClientProperties.ToList().ForEach(x => ctx.ClientProperties.Remove(x));
          ctx.PluginTemplates.Remove(clientDB.PluginTemplate);
          ctx.Clients.Remove(clientDB);
          ctx.SaveChanges();
        }
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
          ctx.Clients.Add(n);

          n.Name = client.Name;
          n.Enabled = client.IsEnabled;

          SetProperty(ctx, n, "Description", client.Properties.Description);
          SetProperty(ctx, n, "IsEnabled", client.Properties.IsEnabled);
          SetProperty(ctx, n, "Name", client.Properties.Name);

          foreach (var cp in client.Properties.Properties)
          {
            SetProperty(ctx, n, cp.Key, cp.Value);
          }

          var cs = ctx.ClientSchedules.Create();
          ctx.ClientSchedules.Add(cs);
          cs.Client = n;
          cs.RunContinuously = client.Schedule.IsRunContinuously;
          cs.RunEverySeconds = client.Schedule.RunEverySeconds;  

          n.PluginTemplate = new PluginTemplate()
          {
            DLLName = client.PluginTemplate.DLLName,
            FullClassName = client.PluginTemplate.FullClassName
          };

        }
        else
        {

          clientDB.Enabled = client.IsEnabled;

          SetProperty(ctx, clientDB, "Description", client.Properties.Description);
          SetProperty(ctx, clientDB, "IsEnabled", client.Properties.IsEnabled);
          SetProperty(ctx, clientDB, "Name", client.Properties.Name);

          foreach (var cp in client.Properties.Properties)
          {
            SetProperty(ctx, clientDB, cp.Key, cp.Value);
          }

          clientDB.ClientSchedules.First().RunContinuously = client.Schedule.IsRunContinuously;
          clientDB.ClientSchedules.First().RunEverySeconds = client.Schedule.RunEverySeconds;

          clientDB.PluginTemplate.DLLName = client.PluginTemplate.DLLName;
          clientDB.PluginTemplate.FullClassName = client.PluginTemplate.FullClassName;

          if (client.Status != null)
          {
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
    private void SetProperty(Entities ctx, Client clientDB, string key, object value)
    {
      var cp = clientDB.ClientProperties.FirstOrDefault(x => x.Key == key);
      if (cp == null)
      {
        cp = ctx.ClientProperties.Create();
        ctx.ClientProperties.Add(cp);

        cp.Client = clientDB;
        cp.Key = key;
        cp.Value = (value ?? "").ToString();
      }
      else
      {
        cp.Value = value.ToString();
      }
    }

  }
}
