using EM.Common.Client.Template;
using EM.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientProperties
  {
    public ClientProperties()
    {
      Properties = new PropertyDictionary();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
    public PropertyDictionary Properties { get; set; }

    public ClientProperties Clone()
    {
      var n = (ClientProperties)this.MemberwiseClone();
      n.Properties = this.Properties.Clone();
      return n;
    }

    public void Populate()
    {
      foreach (var x in this.Properties)
      {
        ConvertUtils.SetPropertyValue(this, x.Key, x.Value);
      }
    }

    //public static ClientProperties GetClientProperties(IClientTemplate template)
    //{
    //  var clientProperties = template.Properties.Clone();
    //  PopulateClientProperties(template, clientProperties);

    //  return clientProperties;
    //}

    //private static void PopulateClientProperties(IClientTemplate template, ClientProperties clientProperties)
    //{
    //  foreach (var x in template.Properties.Properties)
    //  {
    //    ConvertUtils.SetPropertyValue(clientProperties, x.Key, x.Value);
    //  }
    //}

  }
}
