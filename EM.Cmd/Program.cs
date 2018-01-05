using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Cmd
{
  class Program
  {
    static void Main(string[] args)
    {
      Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger("asd");

      logger.Info("hello world");
    }
  }
}
