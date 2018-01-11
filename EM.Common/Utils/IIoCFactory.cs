using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Utils
{
  public interface IIoCFactory
  {
    T GetInstance<T>();
  }
}
