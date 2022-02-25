namespace PierresBakery.Models
{
  public class Pastry
  {
    public string Name { get; init; }
    public int Amount { get; private set; }

    public Pastry(string name, int amount)
    {
      Name = name;
      Amount = amount;
    }
  }
}
