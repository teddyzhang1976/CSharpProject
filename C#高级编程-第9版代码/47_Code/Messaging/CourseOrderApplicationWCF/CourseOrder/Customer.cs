using System.Runtime.Serialization;
namespace Wrox.ProCSharp.Messaging
{
  [DataContract]
  public class Customer : BindableBase
  {
    private string company;
    [DataMember]
    public string Company
    {
      get { return company; }
      set
      {
        SetProperty(ref company, value);
      }
    }

    private string contact;
    [DataMember]
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
