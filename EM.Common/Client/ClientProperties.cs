using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientProperties
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
    public PropertyDictionary Properties { get; set; }
  }
}
