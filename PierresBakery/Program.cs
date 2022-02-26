using System;
using System.Collections.Generic;

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
        { "welcome", "Welcome to Pierre's Bakery\n\n" +
                     "Our specials are: Buy 2 Breads get the 3rd free! and\n" +
                     "                  Buy 3 Pastires for $5!\n" },
        { "goodbye", "Goodbye!" }
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
      for (int i = 0; i < DaysBread.Count; i++)
      {
        string x = "".PadLeft(8) + $"[{i}] {DaysBread[i].Name} ({DaysBread[i].Amount})";
        Console.WriteLine(x);
      }
      for (int i = 0, z = DaysBread.Count; i < DaysPastries.Count; i++)
      {
        string x = "".PadLeft(8) + $"[{i+z}] {DaysPastries[i].Name} ({DaysPastries[i].Amount})";
        Console.WriteLine(x);
      }
    }

    private static Dictionary<string, int> ParseUserSelection(
      Dictionary<string, int> Order,
      string choice,
      string amount)
    {
      int c = int.Parse(choice);
      int a = int.Parse(amount);

      if (a > DaysBread.Count)
      {
        Order[DaysPastries[c].Name] = a;
        Order["_total"] += Bread.GetCost(a);
      }
      else
      {
        Order[DaysBread[c].Name] = a;
        Order["_total"] += Pastry.GetCost(a);
      }
      return Order;
    }

    public static void Main()
    {
      var Order = new Dictionary<string, int>() { { "_total", 0 } };
      BuildBakery();
      Console.WriteLine(Messages["welcome"]);
      while (true)
      {
        DisplayOptions();
        Console.Write("\nWhat item would you like? >>> ");
        string choice = Console.ReadLine();
        Console.Write("And how many would you like? >>> ");
        string amount = Console.ReadLine();
        Order = ParseUserSelection(Order, choice, amount);

        break;
      }
      foreach (var key in Order.Keys)
      {
        if (key == "_total") { continue; }
        System.Console.WriteLine("{0}: {1}", key, String.Join(", ", Order[key]));
      }
      Console.WriteLine("Total: ${0}", Order["_total"]);
      Console.WriteLine(Messages["goodbye"].PadLeft(72, '.'));
    }
  }
}
