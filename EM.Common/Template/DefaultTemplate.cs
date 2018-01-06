using EM.Common.Plugin;
using System;
using System.Linq;
using System.Reflection;

namespace EM.Common.Template
{
  public class DefaultTemplate : ITemplate
  {
    private string dllName;
    private string className;

    public DefaultTemplate(string dllName, string className)
    {
      this.dllName = dllName;
      this.className = className;
    }

    public Type PluginType { get => GetPluginType(); }

    public string DLLName { get => dllName; set => dllName = value; }
    public string FullClassName { get => className; set => className = value; }

    private Type GetPluginType()
    {
      Assembly SampleAssembly;
      SampleAssembly = Assembly.LoadFrom(dllName);
      return SampleAssembly.GetTypes().Where(x => x.FullName == className && x.GetInterfaces().Contains(typeof(IPlugin))).FirstOrDefault();
    }
  }
}
