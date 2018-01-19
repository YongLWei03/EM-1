using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Client;
using EM.Common.Client;
using EM.Common.Client.Template;
using EM.Plugin.Template;

namespace EM.API.Cmd.Model
{
  public class Client
  {
    public Client()
    {
      Properties = new ClientProperties();
      Schedule = new ClientSchedule();
      Plugin = new Plugin();
      Runtime = new ClientRuntime();
    }

    public string Name { get; set; }
    public ClientProperties Properties { get; set; }
    public ClientSchedule Schedule { get; set; }
    public ClientRuntime Runtime { get; set; }
    public Plugin Plugin { get; set; }
 

    public static Model.Client From(IClientTemplate c)
    {
      var client = new Model.Client()
      {
        Name = c.Name,
        Properties = new ClientProperties()
        {
          Description = c.Properties.Description,
          IsEnabled = c.IsEnabled,
        },
        Schedule = new ClientSchedule()
        {
          IsRunContinuously = c.Schedule.IsRunContinuously,
          RunEverySeconds = c.Schedule.RunEverySeconds
        },
        Plugin = new Plugin()
        {
          Name = c.PluginTemplate.FullClassName,
        },
        Runtime = new ClientRuntime()
        {
          LastRun = c.Status.LastRun,
          LastLifeSign = c.Status.LastLifeSign,
          NextRun = c.Status.NextRun
        }
      };
      return client;
    }

    public static IClient To(Client client)
    {
      var c = new DefaultClient()
      {
        Name = client.Name,
        Properties = new Common.Client.ClientProperties()
        {
          Description = client.Properties.Description,
          IsEnabled = client.Properties.IsEnabled,
        },
        Schedule = new Common.Client.ClientSchedule()
        {
          IsRunContinuously = client.Schedule.IsRunContinuously,
          RunEverySeconds = client.Schedule.RunEverySeconds
        },
        PluginTemplate = new DefaultPluginTemplate()
        {
          FullClassName = client.Plugin.Name,
          
        },
        Status = new Common.Client.ClientStatus()
        {
          LastRun = client.Runtime.LastRun,
          LastLifeSign = client.Runtime.LastLifeSign,
          NextRun = client.Runtime.NextRun
        }
      };

      return c;
    }
  }
}
