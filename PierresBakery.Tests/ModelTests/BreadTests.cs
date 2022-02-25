using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using PierresBakery.Models;

namespace PierresBakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestCleanup]
    public void Cleanup()
    {
      Bread.RemoveBreads();
    }

    [TestMethod]
    public void BreadConstructor_CreateInstanceOfBread_Bread()
    {
      Bread testBread = new Bread("", 0);
      Assert.AreEqual(typeof(Bread), testBread.GetType());
    }

    [TestMethod]
    public void BreadItemName_ReturnBreadItemName_String()
    {
      string breadName = "pan francés";
      Bread testBread = new Bread(breadName, 0);

      Assert.AreEqual(breadName, testBread.Name);
    }

    [TestMethod]
    public void BreadAmount_ReturnBreadAmount_Int()
    {
      string breadName = "pan francés";
      int breadAmount = 10;
      Bread testBread = new Bread(breadName, breadAmount);

      Assert.AreEqual(breadAmount, testBread.Amount);
    }

    [TestMethod]
    public void BreadPrice_ReturnBreadPrice_Int()
    {
      string breadName = "pan francés";
      int breadAmount = 10;
      int breadPrice = 5;
      Bread testBread = new Bread(breadName, breadAmount);

      Assert.AreEqual(breadPrice, Bread.Price);
    }

    [TestMethod]
    public void BreadGetBreads_ReturnEmptyList_BreadList()
    {
      List<Bread> emptyBreadList = new List<Bread>();

      CollectionAssert.AreEqual(emptyBreadList, Bread.GetBreads());
    }

    [TestMethod]
    public void BreadGetBreads_ReturnListOfBreads_BreadList()
    {
      List<Bread> fullBreadList = new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      };

      CollectionAssert.AreEqual(fullBreadList, Bread.GetBreads());
    }

    [TestMethod]
    public void BreadClearBreads_ClearsBreadListObjects_True()
    {
      List<Bread> fullBreadList = new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      };
      List<Bread> emptyBreadList = new List<Bread>();

      Bread.RemoveBreads();

      CollectionAssert.AreEqual(emptyBreadList, Bread.GetBreads());
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
      int expectedCost = 10;

      Assert.AreEqual(expectedCost, Bread.GetCost(3));
    }
  }
}
