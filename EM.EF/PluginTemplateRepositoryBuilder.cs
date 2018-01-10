using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
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
        var query = from t in ctx.Templates
                    select t;

        foreach (var t in query)
        {
          repo.Add(t.FullClassName, new DefaultPluginTemplate()
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
