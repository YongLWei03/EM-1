using EM.Common.Plugin;
using EM.Common.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Factory
{
  public interface IFactory
  {
    IClient MakeClient(ITemplate template);
  }
}
