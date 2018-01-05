using EM.Common.Plugin;
using EM.Common.Plugin.Repository;
using EM.Plugin.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Repository.Sample
{
  public class SampleRepository : IRepository
  {
    private Dictionary<string, ITemplate> templates = new Dictionary<string, ITemplate>()
    {
      { "EM.Plugin.Sample.SamplePlugin", new Template("EM.Plugin.Sample.dll", "EM.Plugin.Sample.SamplePlugin")}
    };

    public ITemplate Get(string name)
    {
      return templates[name];
    }
  }
}
