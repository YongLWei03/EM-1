using EM.Common.ClientTemplate;

namespace EM.Common.Client.Factory
{
  public interface IFactory
  {
    IClient MakeClient(IClientTemplate template);
  }
}
