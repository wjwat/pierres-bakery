using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class PastryTests
  {
    string pastryName = "gallina";
    int pastryAmount = 10;
    int pastryPrice = 5;
    Pastry testPastry;
    List<Pastry> emptyPastryList = new List<Pastry>();

    [TestInitialize]
    public void Initialize()
    {
      testPastry = new Pastry(pastryName, pastryAmount);
    }

    [TestCleanup]
    public void Cleanup()
    {
      // do nothing for now
    }

    [TestMethod]
    public void PastryConstructor_CreateInstanceOfPastry_Pastry()
    {
      Assert.AreEqual(typeof(Pastry), testPastry.GetType());
    }

    [TestMethod]
    public void PastryItemName_ReturnPastryItemName_String()
    {
      Assert.AreEqual(pastryName, testPastry.Name);
    }
  }
}
