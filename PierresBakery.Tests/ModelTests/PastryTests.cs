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
    int pastryPrice = 2;
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

    [TestMethod]
    public void PastryAmount_ReturnPastryAmount_Int()
    {
      Assert.AreEqual(pastryAmount, testPastry.Amount);
    }

    [TestMethod]
    public void PastryPrice_ReturnPastryPrice_Int()
    {
      Assert.AreEqual(pastryPrice, Pastry.Price);
    }

    [TestMethod]
    public void PastryClearPastries_ClearsPastryListObjects_True()
    {
      Pastry.RemovePastries();

      CollectionAssert.AreEqual(emptyPastryList, Pastry.GetPastries());
    }

    [TestMethod]
    public void PastryGetPastries_ReturnEmptyList_PastryList()
    {
      // In order to DRY up our code we've put some initalizations in the test
      // Initialize func which means we come into this test with a pastry added.
      Pastry.RemovePastries();

      CollectionAssert.AreEqual(emptyPastryList, Pastry.GetPastries());
    }
  }
}
