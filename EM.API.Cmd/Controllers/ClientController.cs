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
  public class ClientController : ApiController
  {
    private IClientPersistor clientPersistor;
    private IClientTemplateRepositoryBuilder clientBuilder;
    private IPluginTemplateRepositoryBuilder pluginBuilder;

    public ClientController(
      IPluginTemplateRepositoryBuilder pluginBuilder, 
      IClientTemplateRepositoryBuilder clientBuilder,
      IClientPersistor clientPersistor)
    => (this.pluginBuilder, this.clientBuilder, this.clientPersistor) = (pluginBuilder, clientBuilder, clientPersistor);

    // GET: api/<controller>
    [HttpGet]
    public Model.Client[] Get()
    {
      IClientTemplateRepository clients = clientBuilder.Build();
      return clients.Select(c => Model.Client.From(c)).ToArray();     
    }

    // GET api/values/5 
    [Route("{name}")]
    public Model.Client Get([FromUri]string name)
    {
      var client = clientBuilder.Build(name);
      return Model.Client.From(client);
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
