using EM.Common.Client;
using EM.Common.ClientTemplate;
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
      using (var ctx = new Entities())
      {
        var query = from c in ctx.Clients
                    select c;

        foreach (var client in query)
        {
          repo.Add(client.Name, new DefaultClientTemplate()
          {
            Name = client.Name,
            PluginTemplate = pluginTemplates.Get(client.Template.FullClassName),
            Properties = GetProperties(client.ClientProperties)
          });
        }
      }
      return repo;
    }

    private PropertyDictionary GetProperties(ICollection<ClientProperty> clientProperties)
    {
      PropertyDictionary pd = new PropertyDictionary();
      foreach (var cp in clientProperties)
      {
        pd.Add(cp.Key, cp.Value);
      }
      return pd;
    }
  }
}
