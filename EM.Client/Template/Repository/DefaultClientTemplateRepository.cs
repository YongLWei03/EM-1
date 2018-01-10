using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using System.Collections.Generic;

namespace EM.Client.Template.Repository
{
  public class DefaultClientTemplateRepository : IClientTemplateRepository 
  {
    private Dictionary<string, IClientTemplate> templates = new Dictionary<string, IClientTemplate>();

    public void Add(string key, IClientTemplate template)
    {
      templates.Add(key, template);
    }

    public IClientTemplate this[string key]
    {
      get { return templates[key]; }
      set { templates[key] = value; }
    }

  }
}
