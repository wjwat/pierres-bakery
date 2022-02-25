using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    string breadName = "pan francés";
    int breadAmount = 10;
    int breadPrice = 5;
    Bread testBread;
    List<Bread> emptyBreadList = new List<Bread>();


    [TestInitialize]
    public void Initialize()
    {
      testBread = new Bread(breadName, breadAmount);
    }

    [TestCleanup]
    public void Cleanup()
    {
      Bread.RemoveBreads();
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
    public void BreadClearBreads_ClearsBreadListObjects_True()
    {
      Bread.RemoveBreads();

      CollectionAssert.AreEqual(emptyBreadList, Bread.GetBreads());
    }

    [TestMethod]
    public void BreadGetBreads_ReturnEmptyList_BreadList()
    {
      // In order to DRY up our code we've put some initalizations in the test
      // Initialize func which means we come into this test with a bread added.
      Bread.RemoveBreads();

      CollectionAssert.AreEqual(emptyBreadList, Bread.GetBreads());
    }

    [TestMethod]
    public void BreadGetBreads_ReturnListOfBreads_BreadList()
    {
      // Same as previous test.
      Bread.RemoveBreads();
      List<Bread> fullBreadList = new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      };

      CollectionAssert.AreEqual(fullBreadList, Bread.GetBreads());
    }

    [TestMethod]
    public void BreadGetTotal_ReturnTotalBasedOnValuePassed_Int()
    {
      int expectedCost = 10;

      Assert.AreEqual(expectedCost, Bread.GetCost(2));
    }

    [TestMethod]
    public void BreadGetTotal_ReturnTotalBasedOnValuePassedWithDiscount_Int()
    {
      int expectedCost = 40;

      Assert.AreEqual(expectedCost, Bread.GetCost(11));
    }
  }
}
