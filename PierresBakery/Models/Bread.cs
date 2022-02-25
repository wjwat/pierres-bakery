using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Bread
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    private static List<Bread> _BreadItems = new List<Bread>();
    public static readonly int Price = 5;

    public Bread(string name, int amount)
    {
      Name = name;
      Amount = amount;

      _BreadItems.Add(this);
    }

    public static List<Bread> GetBreads()
    {
      return _BreadItems;
    }

    public static void RemoveBreads()
    {
      _BreadItems.Clear();
    }

    public static int GetCost(int numberOfBreads)
    {
      return (numberOfBreads - (numberOfBreads / 3)) * Price;
    }
  }
}
