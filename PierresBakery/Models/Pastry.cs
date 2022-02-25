using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Pastry
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    private static List<Pastry> _PastryItems = new List<Pastry>();
    public static readonly int Price = 2;

    public Pastry(string name, int amount)
    {
      Name = name;
      Amount = amount;

      _PastryItems.Add(this);
    }

    public static List<Pastry> GetPastries()
    {
      return new List<Pastry> {
        new Pastry("fail", 0)
      };
    }

    public static void RemovePastries()
    {
      _PastryItems.Clear();
    }

  }
}
