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
      Bread testBread = new Bread("", 0);
      Assert.AreEqual(typeof(Bread), testBread.GetType());
    }

    [TestMethod]
    public void BreadItemName_ReturnBreadItemName_String()
    {
      string breadName = "pan francés";
      Bread testBread = new Bread(breadName, 0);

      Assert.AreEqual(breadName, testBread.Name);
    }

    [TestMethod]
    public void BreadAmount_ReturnBreadAmount_Int()
    {
      string breadName = "pan francés";
      int breadAmount = 10;
      Bread testBread = new Bread(breadName, breadAmount);

      Assert.AreEqual(breadAmount, testBread.Amount);
    }
  }
}
