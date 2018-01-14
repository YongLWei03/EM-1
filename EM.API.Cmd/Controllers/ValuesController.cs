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
    private IClientTemplateRepositoryBuilder builder;

    //  public ValuesController(IClientTemplateRepositoryBuilder builder) => this.builder = builder;

    // GET: api/<controller>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      IPluginTemplateRepositoryBuilder pluginBuilder = new PluginTemplateRepositoryBuilder();
      IClientTemplateRepositoryBuilder builder = new ClientTemplateRepositoryBuilder(pluginBuilder);
      IClientTemplateRepository clients = builder.Build();
      IList<string> cn = new List<string>();
      foreach (var c in clients)
      {
        cn.Add(c.Name);
      }
      return cn.ToArray();//new string[] { "1", "2" }; //
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
