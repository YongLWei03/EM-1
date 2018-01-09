using EM.Common.PluginTemplate;
using System.Collections.Generic;

namespace EM.EF
{
  public class TemplateRepositoryInitializer : System.Data.Entity.CreateDatabaseIfNotExists<EMContext> //DropCreateDatabaseAlways
  {
    protected override void Seed(EMContext context)
    {
      var templates = new List<DefaultPluginTemplate>()
      {
        new DefaultPluginTemplate("EM.Plugin.Sample.dll", "EM.Plugin.Sample.SamplePlugin")
      };

      templates.ForEach(t => context.Templates.Add(t));
      context.SaveChanges();
    }
  }
}
