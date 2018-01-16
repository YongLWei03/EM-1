using System;
using EM.Common.Client.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.EF.Tests
{
  [TestClass]
  public class WashUpRepositoryTest
  {
    [TestMethod]
    public void RemoveOldStatusTest()
    {
      IWashUpRepository target = new WashUpRepository();
      target.RemoveOldStatus();
    }
  }
}
