using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Plugin.Repository
{
  public interface IRepository
  {
    ITemplate Get(string name);
  }
}
