namespace PierresBakery.Models
{
  public class Bread
  {
    public string Name { get; init; }
    public int Amount { get; init; }

    public Bread(string name, int amount)
    {
      Name = name;
    }
  }
}
