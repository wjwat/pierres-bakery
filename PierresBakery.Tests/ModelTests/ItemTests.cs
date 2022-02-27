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

    [TestInitialize]
    public void Initialize()
    {
      testItem = new Item(itemName);
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
  }
}
