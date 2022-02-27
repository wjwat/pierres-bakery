using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class ItemTests
  {
    Item testItem;
    string itemName = "Test Item";
    int itemAmount = 10;
    int sellAmount = 5;
    int totalLeft = 5;

    [TestInitialize]
    public void Initialize()
    {
      testItem = new Item(itemName, itemAmount);
    }

    [TestMethod]
    public void ItemConstructor_CreateInstanceOfItem_Item()
    {
      Assert.AreEqual(typeof(Item), testItem.GetType());
    }

    [TestMethod]
    public void ItemItemName_ReturnItemItemName_String()
    {
      Assert.AreEqual(itemName, testItem.Name);
    }

    [TestMethod]
    public void ItemAmount_ReturnItemAmount_Int()
    {
      Assert.AreEqual(itemAmount, testItem.Amount);
    }

    [TestMethod]
    public void ItemPrice_CheckItemHasPriceProperty_True()
    {
      var result = testItem.GetType().GetProperty("Price") != null;
      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void ItemSell_SellMethodCorrectlyChanges_Int()
    {
      testItem.Sell(sellAmount);
      Assert.AreEqual(totalLeft, testItem.Amount);
    }

    [TestMethod]
    public void ItemSell_SellMethodOnlySellsMaxAmount_Int()
    {
      testItem.Sell(itemAmount+1);
      Assert.AreEqual(itemAmount, testItem.Amount);
    }
  }
}
