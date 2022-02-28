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
      Assert.AreEqual(pastryPrice, testPastry.Price);
    }

    [TestMethod]
    public void PastryGetTotal_ReturnTotalBasedOnValuePassed_Int()
    {
      int expectedCost = 4;

      Assert.AreEqual(expectedCost, testPastry.Cost(2));
    }

    [TestMethod]
    public void PastryGetTotal_ReturnTotalBasedOnValuePassedWithDiscount_Int()
    {
      int expectedCost = 10;

      Assert.AreEqual(expectedCost, testPastry.Cost(6));
    }

    [TestMethod]
    public void PastrySellPastry_ReturnTrueIfPastryExists_True()
    {
      Assert.AreEqual(true, testPastry.Sell(pastryAmount));
    }

    [TestMethod]
    public void PastrySellPastry_ModifyPastryAmount_True()
    {
      Pastry newTestPastry = new Pastry("test", 10);
      int sellAmount = 6;
      int expectedAmount = 4;
      newTestPastry.Sell(sellAmount);

      Assert.AreEqual(expectedAmount, newTestPastry.Amount);
    }

    [TestMethod]
    public void PastrySellPastry_SellAmountExceedsNumberOfPastries_False()
    {
      Pastry newTestPastry = new Pastry("test", 10);
      int sellAmount = 11;

      Assert.AreEqual(false, newTestPastry.Sell(sellAmount));
    }
  }
}
