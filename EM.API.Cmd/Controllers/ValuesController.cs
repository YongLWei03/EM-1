using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.EF;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EM.API.Cmd.Controllers
{
  [Route("api/[controller]")]
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class ValuesController : ApiController
  {
    private IClientPersistor clientPersistor;
    private IClientTemplateRepositoryBuilder clientBuilder;
    private IPluginTemplateRepositoryBuilder pluginBuilder;

    public ValuesController(
      IPluginTemplateRepositoryBuilder pluginBuilder, 
      IClientTemplateRepositoryBuilder clientBuilder,
      IClientPersistor clientPersistor)
    => (this.pluginBuilder, this.clientBuilder, this.clientPersistor) = (pluginBuilder, clientBuilder, clientPersistor);

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
      return clients.Select(c => new Model.Client()
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
    public HttpResponseMessage Post([FromBody]Model.Client client)
    {
      clientPersistor.ToggleEnable(client.Name, client.IsEnabled);
      var resp = Request.CreateResponse<Model.Client>(System.Net.HttpStatusCode.OK, client);
      return resp;
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
