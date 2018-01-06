using EM.Common.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EF
{
  public class TemplateRepositoryInitializer : System.Data.Entity.CreateDatabaseIfNotExists<EMContext> //DropCreateDatabaseAlways
  {
    protected override void Seed(EMContext context)
    {
      var templates = new List<DefaultTemplate>()
      {
        new DefaultTemplate("EM.Plugin.Sample.dll", "EM.Plugin.Sample.SamplePlugin")
      };

      templates.ForEach(t => context.Templates.Add(t));
      context.SaveChanges();
    }
  }
}
