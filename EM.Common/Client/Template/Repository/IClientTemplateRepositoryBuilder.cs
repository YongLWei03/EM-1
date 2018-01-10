using EM.Common.ClientTemplate.Repository;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Template.Repository
{
  public interface IClientTemplateRepositoryBuilder
  {
    IClientTemplateRepository Build(IPluginTemplateRepository pluginTemplates);
  }
}
