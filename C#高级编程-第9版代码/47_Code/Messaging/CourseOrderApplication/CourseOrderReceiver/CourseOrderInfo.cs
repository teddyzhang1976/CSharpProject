using System.Windows;

namespace Wrox.ProCSharp.Messaging
{
  public class CourseOrderInfo : BindableBase
  {
    public CourseOrderInfo()
    {
      Clear();
    }

    private MessageInfo messageInfo;
    public MessageInfo MessageInfo
    {
      get { return messageInfo; }
      set
      {
        SetProperty(ref messageInfo, value);
      }
    }

    private string course;
    public string Course
    {
      get { return course; }
      set 
      { 
        SetProperty(ref course, value); 
      }
    }

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

    private bool enableProcessing;
    public bool EnableProcessing
    {
      get
      {
        return enableProcessing;
      }
      set
      {
        SetProperty(ref enableProcessing, value);
      }
    }

    private Visibility highPriority;
    public Visibility HighPriority
    {
      get
      {
        return highPriority;
      }
      set
      {
        SetProperty(ref highPriority, value);
      }
    }

    public void Clear()
    {
      Course = string.Empty;
      Company = string.Empty;
      Contact = string.Empty;
      EnableProcessing = false;
      HighPriority = Visibility.Hidden;
    }
  }
}
