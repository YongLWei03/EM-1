using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Plugin
{
  public class Template : ITemplate
  {
    private string dllName;
    private string className;
    
    public Template(string dllName, string className) 
    {
      this.dllName = dllName;
      this.className = className;
    }

    public Type PluginType { get => GetPluginType(); }

    private Type GetPluginType()
    {
      Assembly SampleAssembly;
      SampleAssembly = Assembly.LoadFrom(dllName);
      return SampleAssembly.GetTypes().Where(x => x.FullName == className && x.GetInterfaces().Contains(typeof(IPlugin))).FirstOrDefault();
    }
  }
}
