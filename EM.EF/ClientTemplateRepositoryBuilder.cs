﻿using EM.Client.Template;
using EM.Client.Template.Repository;
using EM.Common;
using EM.Common.Client;
using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM.EF
{
  public class ClientTemplateRepositoryBuilder : IClientTemplateRepositoryBuilder
  {
    protected IPluginTemplateRepositoryBuilder pluginTemplateRepositoryBuilder;

    public ClientTemplateRepositoryBuilder(IPluginTemplateRepositoryBuilder pluginTemplateRepositoryBuilder)
      => this.pluginTemplateRepositoryBuilder = pluginTemplateRepositoryBuilder;


    public virtual IClientTemplateRepository Build()
    {
      IPluginTemplateRepository pluginTemplates = pluginTemplateRepositoryBuilder.Build();

      IClientTemplateRepository repo = new DefaultClientTemplateRepository();
      using (var ctx = new Entities())
      {
        var query = from c in ctx.Clients
                    select c;

        foreach (var client in query)
        {
          repo.Add(client.Name,
            BuildClientTemplate(client, pluginTemplates[client.PluginTemplate.FullClassName]));
        }
      }
      return repo;
    }

    public virtual IClientTemplate Build(string clientName)
    {
      IClientTemplate ct = null;

      using (var ctx = new Entities())
      {
        var client = (from c in ctx.Clients
                      where c.Name == clientName
                      select c).FirstOrDefault();

        if (client != null)
        {
          IPluginTemplate pluginTemplate = pluginTemplateRepositoryBuilder.Build(client.PluginTemplate.FullClassName);
          ct = BuildClientTemplate(client, pluginTemplate);
        }
      }

      return ct;
    }

    protected IClientTemplate BuildClientTemplate(Client client, IPluginTemplate pluginTemplate)
    {
      IClientTemplate ct = null;
      if (client != null)
      {
        ct = new DefaultClientTemplate()
        {
          Name = client.Name,
          PluginTemplate = pluginTemplate,
          Properties = GetProperties(client.ClientProperties),
          Schedule = GetSchedule(client.ClientSchedules.First()),
          Status = GetStatus(client.ClientStatus),
        };
        ct.Name = client.Name;
        ct.IsEnabled = client.Enabled;
      }
      return ct;
    }

    protected ClientStatus GetStatus(ICollection<ClientStatu> clientStatus)
    {
      ClientStatus status = new ClientStatus()
      {
        LastRun = DateTime.MinValue,
        LastLifeSign = DateTime.MinValue
      };
      var latest = clientStatus.OrderByDescending(x => x.DateTime).FirstOrDefault();
      if (latest != null)
      {
        status.LastRun = latest.LastRun;
        status.LastLifeSign = latest.LastLifeSign;
        status.NextRun = latest.NextRun;
      }
      return status;
    }

    protected Common.Client.ClientSchedule GetSchedule(ClientSchedule clientSchedule)
    {
      Common.Client.ClientSchedule schedule = new Common.Client.ClientSchedule()
      {
        IsRunContinuously = clientSchedule.RunContinuously,
        RunEverySeconds = clientSchedule.RunEverySeconds
      };
      return schedule;
    }

    protected ClientProperties GetProperties(ICollection<ClientProperty> propertyList)
    {
      ClientProperties clientProperties = new ClientProperties();
      foreach (var cp in propertyList)
      {
        clientProperties.Properties.Add(cp.Key, cp.Value);
      }
      clientProperties.Populate();
      return clientProperties;
    }
  }
}
