using EM.Client.Template;
using EM.Client.Template.Repository;
using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class PrimalClientTemplateRepositoryBuilder : ClientTemplateRepositoryBuilder, IClientTemplateRepositoryBuilder
  {
    public PrimalClientTemplateRepositoryBuilder(IPluginTemplateRepositoryBuilder pluginTemplateRepositoryBuilder) : base(pluginTemplateRepositoryBuilder) { }

    public override IClientTemplateRepository Build()
    {
      IPluginTemplateRepository pluginTemplates = pluginTemplateRepositoryBuilder.Build();

      IClientTemplateRepository repo = new DefaultClientTemplateRepository();
      using (var ctx = new Entities())
      {
        var client = (from c in ctx.Clients
                      where c.Name == "Primal Client"
                      select c).FirstOrDefault();

        repo.Add(client.Name,
          BuildClientTemplate(client, pluginTemplates[client.PluginTemplate.FullClassName]));

      }
      return repo;
    }
  }
}
