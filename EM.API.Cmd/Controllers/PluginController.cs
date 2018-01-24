using EM.Common.Plugin.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EM.API.Cmd.Controllers
{
  [Route("api/[controller]")]
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class PluginController : ApiController
  {
    private IPluginTemplateRepositoryBuilder pluginBuilder;

    public PluginController(IPluginTemplateRepositoryBuilder pluginBuilder) => (this.pluginBuilder) = (pluginBuilder);


  // GET: api/<controller>
  [HttpGet]
  public Model.Plugin[] Get()
  {
      var plugins = pluginBuilder.Build();
      return plugins.Select(p => Model.Plugin.From(p)).ToArray();
    }
}
}
