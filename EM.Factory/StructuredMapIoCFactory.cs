using EM.Common.Client.Repository;
using EM.Common.Client.Template.Repository;
using EM.Common.Plugin.Template.Repository;
using EM.Common.PluginTemplate.Repository;
using EM.Common.Utils;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Factory
{
  public class StructuredMapIoCFactory : IIoCFactory
  {
    private Container container;
    private Dictionary<Type, Func<object>> actions;

    public StructuredMapIoCFactory()
    {
      container = new Container(c => { c.AddRegistry<StructuredMapRegistry>(); });
    }

    public T GetInstance<T>()
    {
      return container.GetInstance<T>();
    }

    public object GetInstance(Type t)
    {
      return container.GetInstance(t);
    }
  }
}
