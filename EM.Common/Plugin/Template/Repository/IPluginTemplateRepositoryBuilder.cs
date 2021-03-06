﻿using EM.Common.PluginTemplate;
using EM.Common.PluginTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Plugin.Template.Repository
{
  public interface IPluginTemplateRepositoryBuilder
  {
    IPluginTemplateRepository Build();
    IPluginTemplate Build(string fullClassName);
  }
}
