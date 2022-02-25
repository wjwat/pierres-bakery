using System;
using System.Collections.Generic;

using PierresBakery.Models;

namespace PierresBakery
{
  public class Program
  {
    public static List<Item> Inventory = new List<Item>();
    // public static List<Pastry> DaysPastries = new List<Pastry>();

    public static Dictionary<string, string> Messages = 
      new Dictionary<string, string>()
      {
        { "welcome", "Welcome to Pierre's Bakery\n\n" +
                     "Our specials are: Buy 2 Breads get the 3rd free! and\n" +
                     "                  Buy 3 Pastires for $5!\n" },
        { "goodbye", "Goodbye!" }
      };

    public static void BuildBakery()
    {
      Inventory.AddRange(new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      });
      // DaysPastries.AddRange(new List<Pastry> {
      //   new Pastry("concha", 15),
      //   new Pastry("gallina", 20),
      //   new Pastry("empanada (pumpkin)", 8),
      // });
    }

    public static string DisplayOptions(string message)
    {
      for (int i = 0; i < Inventory.Count; i++)
      {
        string x = "".PadLeft(8) + $"[{i}] {Inventory[i].Name} ({Inventory[i].Amount})";
        Console.WriteLine(x);
      }

    //   Console.WriteLine("Pastries:".PadLeft(10));
    //   for (int i = 0; i < DaysPastries.Count; i++)
    //   {
    //     int z = i+DaysBread.Count;
    //     string x = "".PadLeft(8) + $"[{z}] {DaysPastries[i].Name} ({DaysPastries[i].Amount})";
    //     Console.WriteLine(x);
    //   }

      Console.Write(message);

      return Console.ReadLine();
    }

    public static Dictionary<string, int> ParseSelection(
      string sel,
      Dictionary<string, int> Order)
    {
      if (sel[0] != 'B' || sel[0] != 'P')
      {
        Console.WriteLine("ERROR: Please enter a valid selection.");
      }
      return Order;
    }

    public static void Main()
    {
      var Order = new Dictionary<string, int>();
      BuildBakery();
      Console.WriteLine(Messages["welcome"]);
      while (true)
      {
        string sel = DisplayOptions("\nWhat item would you like? >>> ");
        Order = ParseSelection(sel.ToUpper(), Order);
      }
      Console.WriteLine(Messages["goodbye"].PadLeft(72, '.'));
    }
  }
}
