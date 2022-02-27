using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Item
  {
    public string Name { get; init; }

    public Item(string name)
    {
      Name = name;
    }
  }
}
