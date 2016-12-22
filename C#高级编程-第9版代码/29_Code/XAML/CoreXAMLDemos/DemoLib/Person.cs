
namespace Wrox.ProCSharp.XAML
{
  public class Person
  {
    public Person()
    {
      FirstName = "one";
      LastName = "two";
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1}", FirstName, LastName);
    }
  }
}
