using System;
using EM.Client;
using EM.Common.Client;
using EM.Common.Client.Repository;
using EM.Plugin.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.EF.Tests
{
  [TestClass]
  public class ClientEFRepositoryTest
  {
    [TestMethod]
    public void UpdateTest()
    {
      IClientPersistor target = new ClientEFRepository();

      IClient client = MakeSampleClient();

      target.Delete(client);
      target.Update(client);

      PluginTemplateRepositoryBuilder pbuilder = new PluginTemplateRepositoryBuilder();
      ClientTemplateRepositoryBuilder cbuilder = new ClientTemplateRepositoryBuilder(pbuilder);

      var actual = cbuilder.Build(client.Name);

      Assert.IsNotNull(actual);
    }

    private IClient MakeSampleClient()
    {
      IClient client = new DefaultClient();

      client.Name = "test";
      client.IsEnabled = true;
      client.PluginTemplate = new DefaultPluginTemplate()
      {
        DLLName = "dllname",
        FullClassName = "fullclassname"
      };
      //client.Properties = new ClientProperties()
      //{
      //  Description = "description",
      //  IsEnabled = true,
      //  Name = client.Name,
      //};
      client.Schedule = new Common.Client.ClientSchedule()
      {
        IsRunContinuously = true,
        RunEverySeconds = 34
      };

      return client;
    }
  }
}
