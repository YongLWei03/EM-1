using EM.Common.Client.Runtime;
using EM.Common.Client.Template;
using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public interface IClient : IClientTemplate
  {
    bool Running { get; set; }

    IPlugin Plugin { get; set; }
    ClientRuntimeProperties RuntimeProperties { get; set; }

  }
}
