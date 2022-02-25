using Microsoft.VisualStudio.TestTools.UnitTesting;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void BreadConstructor_CreateInstanceOfBread_Bread()
    {
      Bread testBread = new Bread("");
      Assert.AreEqual(typeof(Bread), testBread.GetType());
    }

    [TestMethod]
    public void BreadItemName_ReturnBreadItemName_String()
    {
      string breadName = "pan francés";
      Bread testBread = new Bread(breadName);

      Assert.AreEqual(breadName, testBread.Name);
    }
  }
}
