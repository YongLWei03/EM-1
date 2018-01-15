using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Repository
{
  public interface IClientPersistor
  {
    void Update(IClient client);
    void ToggleEnable(string clientName, bool isEnabled);
  }
}
