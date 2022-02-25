namespace PierresBakery.Models
{
  public class Bread
  {
    public string Name { get; init; }
    public int Amount { get; private set; }
    public int Price { get; }

    public Bread(string name, int amount)
    {
      Name = name;
      Amount = amount;
    }
  }
}
