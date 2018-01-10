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
    protected PropertyDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
