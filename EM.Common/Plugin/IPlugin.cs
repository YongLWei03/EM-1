using EM.Common.Client;

namespace EM.Common.Plugin
{
  public interface IPlugin
  {
    PropertyDictionary Properties { get; set; }
    bool Running { get; }

    void Run();
    void Stop();
  }
}
