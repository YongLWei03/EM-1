using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Client.Template;
using EM.Common.Plugin;
using EM.Common.Utils;
using System;
using System.Reflection;

namespace EM.Client.Factory
{
  public class DefaultClientFactory : IClientFactory
  {
    public DefaultClientFactory()
    {

    }

    public IClient MakeClient(IClientTemplate template)
    {
      // Construct and initialize settings for a second AppDomain.
      AppDomainSetup ads = new AppDomainSetup();
      ads.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;

      ads.DisallowBindingRedirects = false;
      ads.DisallowCodeDownload = true;
      ads.ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

      // Create the second AppDomain.
      AppDomain ad = AppDomain.CreateDomain("AD #2", null, ads);
      //ad.FirstChanceException += Ad_FirstChanceException;
      //ad.UnhandledException += Ad_UnhandledException;

      Type t = template.PluginTemplate.PluginType;

      IPlugin plugin = (IPlugin)ad.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);
      plugin.Properties = template.Properties;

      DefaultClient client = new DefaultClient()
      {
        AppDomain = ad,
        Plugin = plugin,
        Properties = GetClientProperties(template)
      };
     
      return client;

    }

    private ClientProperties GetClientProperties(IClientTemplate template)
    {
      var properties = new ClientProperties()
      {
        Properties = template.Properties.Clone()
      };
      PopulateClientProperties(template, properties);

      return properties;
    }

    private void PopulateClientProperties(IClientTemplate template, ClientProperties clientProperties)
    {
      foreach (var x in template.Properties)
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
  }
}
