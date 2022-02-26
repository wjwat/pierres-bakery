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
    int pastryAmount = 6;
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
      Pastry.RemovePastries();
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

    [TestMethod]
    public void PastryGetPastries_ReturnListOfPastries_PastryList()
    {
      // Same as previous test.
      Pastry.RemovePastries();
      List<Pastry> fullPastryList = new List<Pastry> {
        new Pastry("pan francés", 10),
        new Pastry("pan de muerto", 5),
        new Pastry("pan de yema", 7),
      };

      CollectionAssert.AreEqual(fullPastryList, Pastry.GetPastries());
    }

    [TestMethod]
    public void PastryGetTotal_ReturnTotalBasedOnValuePassed_Int()
    {
      int expectedCost = 4;

      Assert.AreEqual(expectedCost, Pastry.GetCost(2));
    }

    [TestMethod]
    public void PastryGetTotal_ReturnTotalBasedOnValuePassedWithDiscount_Int()
    {
      int expectedCost = 10;

      Assert.AreEqual(expectedCost, Pastry.GetCost(6));
    }

    [TestMethod]
    public void PastrySellPastry_ReturnTrueIfPastryExists_True()
    {
      Assert.AreEqual(true, Pastry.SellPastry(pastryName, pastryAmount));
    }

    [TestMethod]
    public void PastrySellPastry_ReturnFalseIfPastryDoesNotExist_False()
    {
      Assert.AreEqual(false, Pastry.SellPastry("hello", pastryAmount));
    }

    [TestMethod]
    public void PastrySellPastry_ModifyPastryAmount_True()
    {
      Pastry newTestPastry = new Pastry("test", 10);
      int sellAmount = 6;
      int expectedAmount = 4;
      Pastry.SellPastry("test", sellAmount);

      Assert.AreEqual(expectedAmount, newTestPastry.Amount);
    }
  }
}
