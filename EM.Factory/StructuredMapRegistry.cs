﻿using EM.Client.Factory;
using EM.Client.Repository;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.EF;
using StructureMap;

namespace EM.Factory
{
  public class StructuredMapRegistry : Registry
  {
    public StructuredMapRegistry()
    {
      For<IPluginTemplateRepositoryBuilder>().Use<PluginTemplateRepositoryBuilder>();
      For<IClientTemplateRepositoryBuilder>().Use<ClientTemplateRepositoryBuilder>();
      For<IClientFactory>().Use<DefaultClientFactory>();
      For<IClientRepository>()
        .Use<DefaultClientRepository>()
        .Setter<IClientFactory>().IsTheDefault()
        .Setter<IClientTemplateRepository>().IsTheDefault();
    }
  }
}