namespace PierresBakery.Models
{
  public class Pastry : Item
  {
    public static new readonly int Price = 2;

    public Pastry(string name, int amount) : base(name, amount) {}

    public static new int Cost(int amount)
    {
      return ((amount / 3) * 5) + ((amount % 3) * Price);
    }
  }
}
