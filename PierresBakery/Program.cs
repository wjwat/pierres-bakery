using System;
using System.Collections.Generic;
using System.Linq;

using PierresBakery.Models;

namespace PierresBakery
{
  public class Program
  {
    private static List<Item> Inventory = new List<Item>();

    private static Dictionary<string, string> Messages = 
      new Dictionary<string, string>()
      {
        { "welcome",
@"
+===================================================================+
|                                                                   |
|                    Welcome to Pierre's Bakery!                    |
|                                                                   |
+===================================================================+

                   Our specials for the day are:
                 Buy 2 Breads get the 3rd one free!
                             - and -
                       Buy 3 Pastries for $5
" },
        { "goodbye", 
@"
    +===============================================================+
    |                                                               |
    |                  Thanks for stopping by!                      |
    |                                                               |
    +===============================================================+
" },
        {      "makesense", "PIERRE> You aren't making any sense right now!\n" },
        {   "itemnotfound", "PIERRE> I can't find that item!\n" },
        { "notenoughitems", "PIERRE> I don't even have that many in stock right now!\n" },
      };

    private static void BuildBakery()
    {
      Inventory.AddRange(new List<Item> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
        new Pastry("concha", 15),
        new Pastry("gallina", 20),
        new Pastry("empanada (pumpkin)", 8),
      });
    }

    private static void DisplayOptions()
    {
      for (int i = 0; i < Inventory.Count; i++)
      {
        if (Inventory[i].Amount == 0)
        {
          continue;
        }
        Console.WriteLine("{0,7} {1} ({2}x)", "["+i+"]",
          Inventory[i].Name,
          Inventory[i].Amount);
      }
    }

    private static Dictionary<Item, int> ParseUserSelection(
      Dictionary<Item, int> Order,
      string choice,
      string amount)
    {
      bool cTest = int.TryParse(choice, out int c);
      bool aTest = int.TryParse(amount, out int a);

      if (!cTest || !aTest || c < 0 || a < 1)
      {
        Console.WriteLine(Messages["makesense"]);
        return Order;
      }

      if (c > Inventory.Count)
      {
        Console.WriteLine(Messages["itemnotfound"]);
        return Order;
      }

      bool result = Inventory[c].Sell(a);

      if (!result)
      {
        Console.WriteLine(Messages["notenoughitems"]);
        return Order;
      }

      Order[Inventory[c]] = a;

      return Order;
    }

    private static void DisplayOrderTotal(Dictionary<Item, int> Order)
    {
      int fullTotal = 0;
      int discountedTotal = 0;

      Console.Write("\n");
      Console.WriteLine("{0,4}  {1,-20}  {2}", "Count", "Item Name", "Total");

      foreach (var key in Order.Keys)
      {
        fullTotal += Order[key] * key.Price;
        discountedTotal += key.Cost(Order[key]);

        Console.WriteLine("{0,4}x  {1,-20}  ${2}", Order[key], key.Name, key.Cost(Order[key]));
      }

      Console.WriteLine("".PadLeft(35, '-'));
      Console.WriteLine("{0,32}", "Full Price: $"+fullTotal);
      Console.WriteLine("{0,32}", "w/ Discount: $"+discountedTotal);
      Console.Write("\n");
    }

    public static void Main()
    {
      var Order = new Dictionary<Item, int>();

      BuildBakery();

      Console.WriteLine(Messages["welcome"]);

      while (true)
      {
        DisplayOptions();
        Console.WriteLine("\n\tType 'F' to finish your order!");
        Console.WriteLine("\tType 'T' to view your running total!");
        Console.WriteLine("\tType 'Q' to exit!");
        Console.Write("\nWhat item would you like? >>> ");
        string choice = Console.ReadLine();

        if (choice == "q" || choice == "Q")
        {
          return;
        }
        else if (choice == "f" || choice == "F")
        {
          break;
        }
        else if (choice == "t" || choice == "T")
        {
          DisplayOrderTotal(Order);
          continue;
        }

        Console.Write("And how many would you like? >>> ");
        string amount = Console.ReadLine();
        Console.Write("\n");

        Order = ParseUserSelection(Order, choice, amount);
      }

      DisplayOrderTotal(Order);

      Console.WriteLine(Messages["goodbye"]);
    }
  }
}
