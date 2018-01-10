using EM.Client.Template;
using EM.Client.Template.Repository;
using EM.Common.Client;
using EM.Common.Client.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class ClientTemplateRepositoryBuilder : IClientTemplateRepositoryBuilder
  {
    public IClientTemplateRepository Build(IPluginTemplateRepository pluginTemplates)
    {
      IClientTemplateRepository repo = new DefaultClientTemplateRepository();
      using (var ctx = new Entities())
      {
        var query = from c in ctx.Clients
                    select c;

        foreach (var client in query)
        {
          repo.Add(client.Name, new DefaultClientTemplate()
          {
            Name = client.Name,
            PluginTemplate = pluginTemplates[client.Template.FullClassName],
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
