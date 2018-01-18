using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Common.Client.Template;

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
  }
}
