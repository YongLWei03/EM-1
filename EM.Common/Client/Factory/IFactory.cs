using EM.Common.PluginTemplate;

namespace EM.Common.Client.Factory
{
  public interface IFactory
  {
    IClient MakeClient(ITemplate template);
  }
}
