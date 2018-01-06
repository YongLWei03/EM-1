using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Template.Repository
{
  public interface ITemplateRepository
  {
    ITemplate Get(string name);
  }
}
