using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Item
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    public int Price { get; init; }

    public Item(string name, int amount)
    {
      Name = name;
      Amount = amount;
      Price = 0;
    }

    public void Sell(int amount)
    {
      if (amount <= Amount)
      {
        Amount -= amount;
      }
    }
  }
}
