using EM.Common.Client;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Client.Sample
{
  public class SampleClient : IClient
  {
    public SampleClient()
    {

    }

    public IPlugin Plugin { get; set; }

    public void Run()
    {
      Plugin.Run();
    }
  }
}
