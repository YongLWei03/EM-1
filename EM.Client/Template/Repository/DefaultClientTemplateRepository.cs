using EM.Common.Client.Template;
using EM.Common.Client.Template.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EM.Client.Template.Repository
{
  public class DefaultClientTemplateRepository : IClientTemplateRepository 
  {
    private Dictionary<string, IClientTemplate> templates = new Dictionary<string, IClientTemplate>();

    public IList<string> ClientNames => templates.Keys.ToList();

    public IEnumerable<IClientTemplate> ClientTemplates => templates.Values.AsEnumerable();

    public void Add(string key, IClientTemplate template)
    {
      templates.Add(key, template);
    }

    public IEnumerator<IClientTemplate> GetEnumerator()
    {
      return ReturnEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ReturnEnumerator();
    }

    public IClientTemplate this[string key]
    {
      get { return templates[key]; }
      set { templates[key] = value; }
    }

    private IEnumerator<IClientTemplate> ReturnEnumerator()
    {
      return templates.Values.GetEnumerator();
    }


  }
}
