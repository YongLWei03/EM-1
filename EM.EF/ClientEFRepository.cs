using EM.Common.Client;
using EM.Common.Client.Repository;
using System;
using System.Linq;

namespace EM.EF
{
  public class ClientEFRepository : IClientPersistor
  {
    public void Update(IClient client)
    {
      using (var ctx = new Entities())
      {
        var query = (from s in ctx.Clients
                    where s.Name == client.Name
                    select s).FirstOrDefault();

        query.ClientStatus.Add(new ClientStatu()
        {
          Client = query,
          DateTime = DateTime.Now,
          LastLifeSign = client.Status.LastLifeSign,
          LastRun = client.Status.LastRun
        });

        ctx.SaveChanges();
      }
    }
  }
}
