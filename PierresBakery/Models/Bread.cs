using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Bread
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    public int Price { get; }
    private static List<Bread> _BreadItems = new List<Bread>();

    public Bread(string name, int amount)
    {
      Name = name;
      Amount = amount;
      Price = 5;
    }

    public static List<Bread> GetBreads()
    {
      return _BreadItems;
    }
  }
}
