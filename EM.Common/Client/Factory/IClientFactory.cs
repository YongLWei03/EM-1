using EM.Common.Client.Template;

namespace EM.Common.Client.Factory
{
  public interface IClientFactory
  {
    IClient MakeClient(IClientTemplate template);
  }
}
