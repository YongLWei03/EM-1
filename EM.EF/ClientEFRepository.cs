using EM.Common.Client;
using EM.Common.Client.Repository;
using System;
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

          n.Name = client.Name;
          n.Enabled = client.IsEnabled;

        }
        else
        {
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
  }
}
