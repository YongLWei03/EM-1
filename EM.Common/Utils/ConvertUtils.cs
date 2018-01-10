using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Utils
{
  public static class ConvertUtils
  {
    public static void SetPropertyValue(object obj, string key, string value)
    {
      PropertyInfo prop = obj.GetType().GetProperty(key);
      if (prop != null)
      {
        prop.SetValue(obj, System.Convert.ChangeType(value, prop.PropertyType));
      }
    }
  }
}
