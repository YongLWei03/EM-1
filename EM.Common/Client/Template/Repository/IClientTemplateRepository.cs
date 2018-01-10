using System.Collections.Generic;

namespace EM.Common.Client.Template.Repository
{
  public interface IClientTemplateRepository
  {
    IList<string> ClientNames { get; }
    void Add(string name, IClientTemplate clientTemplate);
    IClientTemplate this[string key] { get; set; }
  }
}