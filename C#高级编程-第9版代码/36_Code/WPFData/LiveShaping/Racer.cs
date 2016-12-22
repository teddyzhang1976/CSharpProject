
namespace Wrox.ProCSharp.WPF
{
  public class Racer
  { 
    public string Name { get; set; }
    public string Team { get; set; }
    public int Number { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
