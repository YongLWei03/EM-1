namespace EM.Common.ClientTemplate.Repository
{
  public interface IClientTemplateRepository
  {
    IClientTemplate Get(string key);
  }
}