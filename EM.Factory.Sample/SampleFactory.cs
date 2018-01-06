using EM.Client.Sample;
using EM.Common.Client;
using EM.Common.Client.Factory;
using EM.Common.Plugin;
using EM.Common.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Factory.Sample
{
  public class SampleFactory : IFactory
  {
    public SampleFactory()
    {

    }

    public IClient MakeClient(ITemplate template)
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

      Type t = template.PluginType;

      IPlugin plugin = (IPlugin)ad.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);

      return new SampleClient(ad,plugin);

    }

    private void Ad_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
    }

    private void Ad_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
    {
    }
  }
}
