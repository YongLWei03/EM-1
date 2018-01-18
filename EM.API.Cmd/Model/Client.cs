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
    public string Name { get; set; }
    public string Description { get; internal set; }
    public string PluginType { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime LastRun { get; set; }
    public DateTime LastLifeSign { get; set; }
    public DateTime NextRun { get; set; }

    internal static Model.Client From(IClientTemplate c)
    {
      var client = new Model.Client()
      {
        Name = c.Name,
        Description = c.Properties.Description,
        PluginType = c.PluginTemplate.FullClassName,
        IsEnabled = c.IsEnabled,
        LastRun = c.Status.LastRun,
        LastLifeSign = c.Status.LastLifeSign,
        NextRun = c.Status.NextRun
      };
      return client;
    }
  }
}
