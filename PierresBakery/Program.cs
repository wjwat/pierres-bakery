using System;
using System.Collections.Generic;

using PierresBakery.Models;

namespace PierresBakery
{
  public class Program
  {
    public static List<Bread> DaysBread = new List<Bread>();
    public static List<Pastry> DaysPastries = new List<Pastry>();

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
      DaysBread.AddRange(new List<Bread> {
        new Bread("pan francés", 10),
        new Bread("pan de muerto", 5),
        new Bread("pan de yema", 7),
      });
    }

    public static string DisplayOptions(string message)
    {
      for (int i = 0; i < DaysBread.Count; i++)
      {
        Console.WriteLine($"[B{i}] {DaysBread[i].Name} ({DaysBread[i].Amount})");
      }

      Console.Write(message);

      return Console.ReadLine();
    }

    public static void Main()
    {
      BuildBakery();
      var Order = new Dictionary<string, int>();
      while (true)
      {
        Console.WriteLine(Messages["welcome"]);
        string x = DisplayOptions("\nWhat item would you like? > ");
      }
      Console.WriteLine(Messages["goodbye"].PadLeft(72, '.'));
    }
  }
}
