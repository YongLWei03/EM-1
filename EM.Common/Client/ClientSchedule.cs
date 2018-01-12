using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientSchedule
  {
    public bool IsRunContinuously { get; set; }
    public int RunEverySeconds { get; set; }

    public ClientSchedule Clone()
    {
      return (ClientSchedule)this.MemberwiseClone();
    }
  }
}
