using EM.Common.Client.Template;

namespace EM.Common.Client.Factory
{
  public interface IFactory
  {
    IClient MakeClient(IClientTemplate template);
  }
}
