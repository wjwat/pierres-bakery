using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    string breadName = "gallina";
    int breadAmount = 6;
    int breadPrice = 2;
    Bread testBread;
    List<Bread> emptyBreadList = new List<Bread>();

    [TestInitialize]
    public void Initialize()
    {
      testBread = new Bread(breadName, breadAmount);
    }

    [TestMethod]
    public void BreadConstructor_CreateInstanceOfBread_Bread()
    {
      Assert.AreEqual(typeof(Bread), testBread.GetType());
    }

    [TestMethod]
    public void BreadItemName_ReturnBreadItemName_String()
    {
      Assert.AreEqual(breadName, testBread.Name);
    }

    [TestMethod]
    public void BreadAmount_ReturnBreadAmount_Int()
    {
      Assert.AreEqual(breadAmount, testBread.Amount);
    }

    [TestMethod]
    public void BreadPrice_ReturnBreadPrice_Int()
    {
      Assert.AreEqual(breadPrice, Bread.Price);
    }

    [TestMethod]
    public void BreadGetTotal_ReturnTotalBasedOnValuePassed_Int()
    {
      int expectedCost = 4;

      Assert.AreEqual(expectedCost, Bread.Cost(2));
    }

    [TestMethod]
    public void BreadGetTotal_ReturnTotalBasedOnValuePassedWithDiscount_Int()
    {
      int expectedCost = 10;

      Assert.AreEqual(expectedCost, Bread.Cost(6));
    }

    [TestMethod]
    public void BreadSellBread_ReturnTrueIfBreadExists_True()
    {
      Assert.AreEqual(true, testBread.Sell(breadAmount));
    }

    [TestMethod]
    public void BreadSellBread_ModifyBreadAmount_True()
    {
      Bread newTestBread = new Bread("test", 10);
      int sellAmount = 6;
      int expectedAmount = 4;
      newTestBread.Sell(sellAmount);

      Assert.AreEqual(expectedAmount, newTestBread.Amount);
    }

    [TestMethod]
    public void BreadSellBread_SellAmountExceedsNumberOfPastries_False()
    {
      Bread newTestBread = new Bread("test", 10);
      int sellAmount = 11;

      Assert.AreEqual(false, newTestBread.Sell(sellAmount));
    }
  }
}
