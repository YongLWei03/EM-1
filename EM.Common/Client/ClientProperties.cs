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
  }
}
