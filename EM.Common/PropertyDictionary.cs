using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common
{
  [Serializable]
  public class PropertyDictionary : Dictionary<string, string>
  {
    public PropertyDictionary() : base() { }
    //public PropertyDictionary(PropertyDictionary pd) : base(pd) { }
    protected PropertyDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public PropertyDictionary Clone()
    {
      return (PropertyDictionary)this.MemberwiseClone();
    }
  }
}
