using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.API.Cmd.Model
{
  public class ClientSchedule
  {
    public bool IsRunContinuously { get; set; }
    public int RunEverySeconds { get; set; }
  }
}
