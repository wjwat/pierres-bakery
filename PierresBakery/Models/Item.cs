using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Item
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    public static readonly int Price = 0;

    public Item(string name, int amount)
    {
      Name = name;
      Amount = amount;
    }

    public bool Sell(int amount)
    {
      if (amount <= Amount)
      {
        Amount -= amount;
        return true;
      }
      else
      {
        return false;
      }
    }

    public static int Cost(int amount)
    {
      return amount * Price;
    }
  }
}
