using EM.Common.Template;
using EM.Common.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EF
{
  public class TemplateRepositoryBuilder
  {
    public DefaultTemplateRepository Build()
    {
      DefaultTemplateRepository repo = new DefaultTemplateRepository();

      //using (var ctx = new EMContext())
      //{
      //  var query = from t in ctx.Templates
      //              select t;

      //  foreach (var t in query)
      //  {
      //    repo.Add(t.FullClassName, t);
      //  }
      //}


      using (var ctx = new EM.EF.EMModel())
      {
        var query = from t in ctx.Templates
                    select t;

        foreach (var t in query)
        {
          repo.Add(t.FullClassName, t);
        }
      }

      return repo;
    }
  }
}
