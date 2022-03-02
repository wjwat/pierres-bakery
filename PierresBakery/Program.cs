using System;
using System.Collections.Generic;
using System.Linq;

using PierresBakery.Models;

namespace PierresBakery
{
  public class Program
  {
    private static List<Bread> DaysBread = new List<Bread>();
    private static List<Pastry> DaysPastries = new List<Pastry>();

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
" }
      };

    private static void BuildBakery()
    {
      DaysBread.AddRange(new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      });
      DaysPastries.AddRange(new List<Pastry> {
        new Pastry("concha", 15),
        new Pastry("gallina", 20),
        new Pastry("empanada (pumpkin)", 8),
      });
    }

    private static void DisplayOptions()
    {
      Console.WriteLine("  $5/ea for Bread, and $2/ea for Pastries");
      for (int i = 0; i < DaysBread.Count; i++)
      {
        if (DaysBread[i].Amount == 0)
        {
          continue;
        }
        Console.WriteLine("{0,7} {1} ({2}x)", "["+i+"]", DaysBread[i].Name, DaysBread[i].Amount);
      }
      for (int i = 0, z = DaysBread.Count; i < DaysPastries.Count; i++)
      {
        if (DaysPastries[i].Amount == 0)
        {
          continue;
        }
        int y = i+z;
        Console.WriteLine("{0,7} {1} ({2}x)", "["+y+"]", DaysPastries[i].Name, DaysPastries[i].Amount);
      }
    }

    private static Dictionary<string, int> ParseUserSelection(
      Dictionary<string, int> Order,
      string choice,
      string amount)
    {
      bool cTest = int.TryParse(choice, out int c);
      bool aTest = int.TryParse(amount, out int a);

      if (!cTest || !aTest || c < 0 || a < 1)
      {
        Console.WriteLine("PIERRE: You aren't making any sense right now!\n");
        return Order;
      }

      if (c > DaysBread.Count + DaysPastries.Count)
      {
        Console.WriteLine("PIERRE: Unable to find that item. Please try again!\n");
        return Order;
      }

      if (c >= DaysBread.Count)
      {
        c -= DaysBread.Count;
        bool result = Pastry.SellPastry(DaysPastries[c].Name, a);

        if (!result)
        {
          Console.WriteLine("PIERRE: Unable to find that item, or sell that amount. Please try again!\n");
          return Order;
        }

        Order[DaysPastries[c].Name] = (Order.ContainsKey(DaysPastries[c].Name)) ? Order[DaysPastries[c].Name] + a : a;
      }
      else
      {
        bool result = Bread.SellBread(DaysBread[c].Name, a);

        if (!result)
        {
          Console.WriteLine("PIERRE: Unable to find that item, or sell that amount. Please try again!\n");
          return Order;
        }

        Order[DaysBread[c].Name] = (Order.ContainsKey(DaysBread[c].Name)) ? Order[DaysBread[c].Name] + a : a;
      }
      return Order;
    }

    private static void DisplayOrderTotal(Dictionary<string, int> Order)
    {
      int discTotal = 0;
      int fullTotal = 0;

      Console.Write("\n");
      Console.WriteLine("{0,4}  {1,-20}  {2}", "Count", "Item Name", "Total");

      foreach (var key in Order.Keys)
      {
        if (IsItemBread(key))
        {
          fullTotal += Order[key] * Bread.Price;
          discTotal += Bread.GetCost(Order[key]);

          Console.WriteLine("{0,4}x  {1,-20}  ${2}", Order[key], key, Bread.GetCost(Order[key]));
        }
        else
        {
          fullTotal += Order[key] * Pastry.Price;
          discTotal += Pastry.GetCost(Order[key]);

          Console.WriteLine("{0,4}x  {1,-20}  ${2}", Order[key], key, Pastry.GetCost(Order[key]));
        }
      }

      Console.WriteLine("".PadLeft(35, '-'));
      Console.WriteLine("{0,32}", "Full Price: $"+fullTotal);
      Console.WriteLine("{0,32}", "w/ Discount: $"+discTotal);
      Console.Write("\n");
    }

    private static bool IsItemBread(string name)
    {
      return Bread.GetBreads().Any(item => item.Name == name);
    }

    public static void Main()
    {
      var Order = new Dictionary<string, int>();

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
