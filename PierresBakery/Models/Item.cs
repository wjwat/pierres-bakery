using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Item
  {
    public string Name { get; init; }
    public int Amount { get; private set; }

    public Item(string name, int amount)
    {
      Name = name;
      Amount = amount;
    }
  }
}
