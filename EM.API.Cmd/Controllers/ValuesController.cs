using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EM.API.Cmd.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : ApiController
  {
    private IClientTemplateRepositoryBuilder clientBuilder;
    private IPluginTemplateRepositoryBuilder pluginBuilder;

    public ValuesController(IPluginTemplateRepositoryBuilder pluginBuilder, IClientTemplateRepositoryBuilder clientBuilder)
    => (this.pluginBuilder, this.clientBuilder) = (pluginBuilder, clientBuilder);

    // GET: api/<controller>
    [HttpGet]
    public object Get()
    {
      IClientTemplateRepository clients = clientBuilder.Build();
      //IList<string> cn = new List<string>();
      //foreach (var c in clients)
      //{
      //  cn.Add(c.Name);
      //}
      return clients.Select(c => new
      {
        Name = c.Name,
        PluginType = c.PluginTemplate.FullClassName,
        IsEnabled = c.IsEnabled,
        LastRun = c.Status.LastRun,
        LastLifeSign = c.Status.LastLifeSign
      }).ToArray();
      //return cn.ToArray();//new string[] { "1", "2" }; //
    }

    // GET api/values/5 
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values 
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5 
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5 
    public void Delete(int id)
    {
    }
  }
}
