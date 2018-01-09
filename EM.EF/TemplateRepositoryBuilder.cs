using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System.Linq;

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
          repo.Add(t.FullClassName, new DefaultTemplate()
          {
            DLLName = t.DLLName,
            FullClassName = t.FullClassName
          });
        }
      }

      return repo;
    }
  }
}
