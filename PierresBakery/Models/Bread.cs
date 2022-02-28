namespace PierresBakery.Models
{
  public class Bread : Item
  {
    public override int Price { get; init; }

    public Bread(string name, int amount) : base(name, amount)
    {
      Price = 5;
    }

    public override int Cost(int amount)
    {
      return (amount - amount / 3) * Price;
    }
  }
}
