using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Template.Repository
{
  public class DefaultTemplateRepository : ITemplateRepository
  {
    private Dictionary<string, ITemplate> templates = new Dictionary<string, ITemplate>();

    public void Add(string name, ITemplate template)
    {
      templates.Add(name, template);
    }

    public ITemplate Get(string name)
    {
      return templates[name];
    }
  }
}
