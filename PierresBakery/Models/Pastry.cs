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
      return _PastryItems;
    }

    public static void RemovePastries()
    {
      _PastryItems.Clear();
    }

    public static int GetCost(int numberOfPastries)
    {
      return ((numberOfPastries / 3) * 5) + ((numberOfPastries % 3) * Price);
    }

    public static bool SellPastry(string name, int amount)
    {
      foreach(Pastry pastry in _PastryItems)
      {
        if (pastry.Name == name && pastry.Amount >= amount)
        {
          pastry.Amount -= amount;
          return true;
        }
      }
      return false;
    }
  }
}
