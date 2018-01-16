using Common.Logging;
using EM.Common.Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EF
{
  public class WashUpRepository : IWashUpRepository
  {
    private ILog logger = LogManager.GetLogger<WashUpRepository>();

    public void RemoveOldStatus()
    {
      using (var ctx = new Entities())
      {
        var listToRemove = ctx.ClientStatus
          .GroupBy(x => x.ClientId)
.Select(x => x.OrderByDescending(y => y.DateTime).Skip(3))
.SelectMany(x => x);

        logger.Debug("Removing " + listToRemove.Count() + " status item(s).");

        ctx.ClientStatus.RemoveRange(listToRemove);

        ctx.SaveChanges();

      }
    }
  }
}
