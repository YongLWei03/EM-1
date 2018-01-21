using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client.Repository
{
  public interface IClientPersistor
  {
    void Delete(string clientName);
    void Delete(IClient client);
    void Update(IClient client);
  }
}
