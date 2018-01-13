using System;
using EM.Common.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Common.Tests.Client
{
  [TestClass]
  public class ClientPropertiesTest
  {
    [TestMethod]
    public void CloneTest()
    {
      string expectedDesc = "desc";
      bool expectedIsEnabled = true;
      string expectedName = "name";
      PropertyDictionary expectedPd = new PropertyDictionary()
      {
        {"key1","value1" }
      };

      ClientProperties target = new ClientProperties()
      {
        Description = expectedDesc,
        IsEnabled = expectedIsEnabled,
        Name = expectedName,
        Properties = expectedPd
      };

      ClientProperties actual = target.Clone();

      Assert.AreEqual(expectedDesc, actual.Description, "Description");
      Assert.AreEqual(expectedIsEnabled, actual.IsEnabled, "IsEnabled");
      Assert.AreEqual(expectedName, actual.Name, "Name");

      foreach (var item in actual.Properties)
      {
        Assert.IsTrue(expectedPd.ContainsKey(item.Key),"Key "+item.Key+" not found.");
        Assert.AreEqual(expectedPd[item.Key], item.Value, "Value " + expectedPd[item.Key] + " not equal to " + item.Value);
      }

    }

    [TestMethod]
    public void PopulateTest()
    {
      PropertyDictionary expectedPd = new PropertyDictionary()
      {
        {"Name","Name1" },
        {"Description","Description1" },
        {"IsEnabled","true" }
      };

      ClientProperties target = new ClientProperties()
      {
        Properties = expectedPd
      };

      Assert.AreNotEqual(expectedPd["Name"], target.Name,"Name");
      Assert.AreNotEqual(expectedPd["Description"], target.Description, "Description");
      Assert.AreNotEqual(bool.Parse(expectedPd["IsEnabled"]), target.IsEnabled, "IsEnabled");

      target.Populate();

      Assert.AreEqual(expectedPd["Name"],target.Name);
      Assert.AreEqual(expectedPd["Description"], target.Description, "Description");
      Assert.AreEqual(bool.Parse(expectedPd["IsEnabled"]), target.IsEnabled, "IsEnabled");
    }

  }
}
