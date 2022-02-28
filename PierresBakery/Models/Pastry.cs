namespace PierresBakery.Models
{
  public class Pastry : Item
  {
    public override int Price { get; init; }

    public Pastry(string name, int amount) : base(name, amount)
    {
      Price = 2;
    }

    public override int Cost(int amount)
    {
      return ((amount / 3) * 5) + ((amount % 3) * Price);
    }
  }
}
