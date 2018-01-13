using EM.Client.Factory;
using EM.Client.Repository;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Runtime;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.Common.Utils;
using EM.EF;
using EM.Plugin;
using StructureMap;

namespace EM.Factory
{
  public class StructuredMapRegistry : Registry
  {
    public StructuredMapRegistry()
    {
      For<IIoCFactory>().Use<StructuredMapIoCFactory>();
      For<IPluginTemplateRepositoryBuilder>().Use<PluginTemplateRepositoryBuilder>();
      For<IClientTemplateRepositoryBuilder>().Use<ClientTemplateRepositoryBuilder>();
      For<IClientPersistor>().Use<ClientPersistor>();
      For<IClientFactory>().Use<DefaultClientFactory>();
      For<IClientRepository>().Use<DefaultClientRepository>();
      For<IClientRuntimeManager>().Use<ClientRuntimeManager>();
    }
  }
}
