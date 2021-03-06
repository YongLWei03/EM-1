﻿using EM.Factory;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.StructureMap;

namespace EM.API.Cmd
{
  public class Startup
  {
    // This code configures Web API. The Startup class is specified as a type
    // parameter in the WebApp.Start method.
    public void Configuration(IAppBuilder appBuilder)
    {
      // Configure Web API for self-host. 
      HttpConfiguration config = new HttpConfiguration();

      config.EnableCors();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{name}",
          defaults: new { name = RouteParameter.Optional }
      );

      config.UseStructureMap<StructuredMapRegistry>();
      
      //appBuilder.UseC
      appBuilder.UseWebApi(config);
    }
  }
}
