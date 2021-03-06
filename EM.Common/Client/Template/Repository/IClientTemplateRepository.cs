﻿using System.Collections.Generic;

namespace EM.Common.Client.Template.Repository
{
  public interface IClientTemplateRepository : IEnumerable<IClientTemplate>
  {
    IList<string> ClientNames { get; }
    IEnumerable<IClientTemplate> ClientTemplates { get; }

    void Add(string name, IClientTemplate clientTemplate);
    IClientTemplate this[string key] { get; set; }
  }
}