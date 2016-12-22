namespace Wrox.ProCSharp.Messaging
{
  public class Customer : BindableBase
  {
    private string company;

    public string Company
    {
      get { return company; }
      set
      {
        SetProperty(ref company, value);
      }
    }

    private string contact;

    public string Contact
    {
      get { return contact; }
      set
      {
        SetProperty(ref contact, value);
      }
    }
  }
}
