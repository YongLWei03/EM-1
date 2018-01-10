namespace EM.Common.Client.Template.Repository
{
  public interface IClientTemplateRepository
  {
    void Add(string name, IClientTemplate clientTemplate);
    IClientTemplate this[string key] { get; set; }
  }
}