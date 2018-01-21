using EM.Client;
using EM.Client.Template;
using EM.Common.Client;
using EM.Common.Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class ClientEFRepository : IClientPersistor
  {

    public void Delete(IClient client)
    {
      using (var ctx = new Entities())
      {
        var clientDB = (from s in ctx.Clients
                        where s.Name == client.Name
                        select s).FirstOrDefault();

        if (clientDB != null)
        {
          clientDB.ClientSchedules.ToList().ForEach(x => ctx.ClientSchedules.Remove(x));
          clientDB.ClientProperties.ToList().ForEach(x => ctx.ClientProperties.Remove(x));
          //ctx.PluginTemplates.Remove(clientDB.PluginTemplate);
          clientDB.ClientStatus.ToList().ForEach(x => ctx.ClientStatus.Remove(x));
          ctx.Clients.Remove(clientDB);
          ctx.SaveChanges();
        }
      }
    }

    public void Delete(string clientName)
    {
      Delete(new DefaultClient() { Name = clientName });
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
          clientDB = ctx.Clients.Create();
          ctx.Clients.Add(clientDB);

          clientDB.Name = client.Name;
          clientDB.Enabled = client.IsEnabled;

          SetProperty(ctx, clientDB, "Description", client.Properties.Description);
          SetProperty(ctx, clientDB, "IsEnabled", client.Properties.IsEnabled);
          SetProperty(ctx, clientDB, "Name", client.Properties.Name);

          foreach (var cp in client.Properties.Properties)
          {
            SetProperty(ctx, clientDB, cp.Key, cp.Value);
          }

          var cs = ctx.ClientSchedules.Create();
          ctx.ClientSchedules.Add(cs);
          cs.Client = clientDB;
          cs.RunContinuously = client.Schedule.IsRunContinuously;
          cs.RunEverySeconds = client.Schedule.RunEverySeconds;

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

        var pt = ctx.PluginTemplates.Where(x => x.FullClassName == client.PluginTemplate.DLLName).FirstOrDefault();
        if (pt == null)
        {
          pt = ctx.PluginTemplates.Create();
          ctx.PluginTemplates.Add(pt);
          pt.DLLName = client.PluginTemplate.DLLName;
          pt.FullClassName = client.PluginTemplate.FullClassName;
        }
        clientDB.PluginTemplate = pt;

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
