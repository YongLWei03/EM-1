using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using EM.Plugin.Template;
using EM.Plugin.Template.Repository;
using System.Linq;

namespace EM.EF
{
  public class PluginTemplateRepositoryBuilder : IPluginTemplateRepositoryBuilder
  {
    public IPluginTemplateRepository Build()
    {
      IPluginTemplateRepository repo = new DefaultPluginTemplateRepository();

      using (var ctx = new Entities())
      {
        var query = from t in ctx.PluginTemplates
                    select t;

        foreach (var ptdb in query)
        {
          repo.Add(ptdb.FullClassName, BuildPluginTemplate(ptdb));
        }
      }

      return repo;
    }

    public IPluginTemplate Build(string fullClassName)
    {
      IPluginTemplate pt = null;
      using (var ctx = new Entities())
      {
        var ptdb = (from t in ctx.PluginTemplates
                    where t.FullClassName == fullClassName
                    select t).FirstOrDefault();
        pt = BuildPluginTemplate(ptdb);
      }
      return pt;
    }

    private IPluginTemplate BuildPluginTemplate(PluginTemplate ptdb)
    {
      IPluginTemplate pt = null;
      if (ptdb != null)
      {
        pt = new DefaultPluginTemplate()
        {
          DLLName = ptdb.DLLName,
          FullClassName = ptdb.FullClassName
        };
      }
      return pt;
    }
  }
}
