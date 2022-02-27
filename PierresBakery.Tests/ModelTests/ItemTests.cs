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

    [TestInitialize]
    public void Initialize()
    {
      testItem = new Item();
    }

    [TestMethod]
    public void ItemConstructor_CreateInstanceOfItem_Item()
    {
      Assert.AreEqual(typeof(Item), testItem.GetType());
    }
  }
}
