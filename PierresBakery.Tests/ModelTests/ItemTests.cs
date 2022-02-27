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
  }
}
