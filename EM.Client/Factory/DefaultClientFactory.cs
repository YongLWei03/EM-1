using Common.Logging;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Repository;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin;
using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using EM.Common.Utils;
using System;
using System.Reflection;

namespace EM.Client.Factory
{
  [Serializable]
  public class DefaultClientFactory : IClientFactory
  {
    private ILog logger = LogManager.GetLogger<DefaultClientFactory>();
    private IIoCFactory iocFactory;
    private IClientRepository clientRepo = null;

    public DefaultClientFactory(IIoCFactory iocFactory) => (this.iocFactory) = (iocFactory);

    //public IClient MakeClient(IClientTemplate template)
    //{
    //  Init();

    //  // Construct and initialize settings for a second AppDomain.
    //  AppDomainSetup ads = new AppDomainSetup();
    //  ads.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;

    //  ads.DisallowBindingRedirects = false;
    //  ads.DisallowCodeDownload = true;
    //  ads.ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

    //  // Create the second AppDomain.
    //  AppDomain ad = AppDomain.CreateDomain("AD #2", null, ads);
    //  //ad.FirstChanceException += Ad_FirstChanceException;
    //  //ad.UnhandledException += Ad_UnhandledException;

    //  Type t = template.PluginTemplate.PluginType;

    //  IPlugin plugin = (IPlugin)ad.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);
    //  plugin.Properties = template.Properties;
    //  GetPropertiesFromIoC(plugin);

    //  DefaultClient client = new DefaultClient()
    //  {
    //    AppDomain = ad,
    //    Plugin = plugin,
    //    Properties = GetClientProperties(template),
    //    Schedule = GetClientSchedule(template),
    //    Status = GetClientStatus(template)
    //  };
     
    //  return client;

    //}

    public IClient MakeClient(IClientTemplate template)
    {
      Init();

      Type t = template.PluginTemplate.PluginType;

      IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
      plugin.Properties = template.Properties.Properties;
      GetPropertiesFromIoC(plugin);

      DefaultClient client = new DefaultClient()
      {
        Plugin = plugin,
        Properties = GetClientProperties(template),
        Schedule = GetClientSchedule(template),
        Status = GetClientStatus(template)
      };

      return client;
    }

    private void GetPropertiesFromIoC(IPlugin plugin)
    {
      Type t = plugin.GetType();
      foreach (PropertyInfo prop in t.GetProperties())
      {
        try
        {
          Type propType = prop.PropertyType;
          prop.SetValue(plugin, iocFactory.GetInstance(propType));
        }
        catch (Exception e)
        {
          logger.Warn("Failed to populated property using reflection. This could be an error.", e);
        }
      }
    }

    private ClientStatus GetClientStatus(IClientTemplate template)
    {
      return template.Status.Clone();
    }

    private ClientSchedule GetClientSchedule(IClientTemplate template)
    {
      return template.Schedule.Clone();
    }

    private ClientProperties GetClientProperties(IClientTemplate template)
    {
      var clientProperties = template.Properties.Clone();
      PopulateClientProperties(template, clientProperties);

      return clientProperties;
    }

    private void PopulateClientProperties(IClientTemplate template, ClientProperties clientProperties)
    {
      foreach (var x in template.Properties.Properties)
      {
        ConvertUtils.SetPropertyValue(clientProperties, x.Key, x.Value);
      }
    }

    private void Ad_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
    }

    private void Ad_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
    {
    }

    private void Init()
    {
      if (clientRepo == null)
      {
        clientRepo = GetClientRepository();
      }
    }

    private IClientRepository GetClientRepository()
    {
      //TODO move out of here

      IPluginTemplateRepositoryBuilder pluginBuilder = iocFactory.GetInstance<IPluginTemplateRepositoryBuilder>();
      IClientTemplateRepositoryBuilder clientBuilder = iocFactory.GetInstance<IClientTemplateRepositoryBuilder>();
      IClientFactory clientFactory = iocFactory.GetInstance<IClientFactory>();
      IClientRepository clientRepo = iocFactory.GetInstance<IClientRepository>();

      return clientRepo;
    }
  }
}
