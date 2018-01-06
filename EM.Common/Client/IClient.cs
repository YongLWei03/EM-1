using EM.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public interface IClient
  {
    IPlugin Plugin { get; set; }
    ClientProperties Properties { get; set; }

    void Run();
  }
}
