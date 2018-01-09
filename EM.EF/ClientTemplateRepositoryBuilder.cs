using EM.Common.ClientTemplate.Repository;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EF
{
  public class ClientTemplateRepositoryBuilder
  {
    public DefaultClientTemplateRepository Build(IPluginTemplateRepository pluginTemplates)
    {
      DefaultClientTemplateRepository repo = new DefaultClientTemplateRepository();
      using (var ctx = new EM.EF.EMModel())
      {
        var query = from c in ctx.Clients
                    select c;

        foreach (var client in query)
        {
          //repo.Add(client.ClientProperties.Select(x=>x.))
        }
      }
      return repo;
    }
  }
}
