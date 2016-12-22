using System.ComponentModel;
using System.Runtime.Serialization;
namespace Wrox.ProCSharp.Messaging
{
  [DataContract]
  public class CourseOrder : BindableBase
  {
    // public const string CourseOrderQueueName = "FormatName:Public=D99CE5F3–4282–4a97–93EE-E9558B15EB13";
    public const string CourseOrderQueueName = @".\Private$\CourseOrder";

    public CourseOrder()
    {
      customer = new Customer();
      course = new Course();
    }

    private Customer customer;
    [DataMember]
    public Customer Customer
    {
      get { return customer; }
      set
      {
        if (!object.Equals(customer, value))
        {
          customer = value;
          OnPropertyChanged("Customer");
        }
      }
    }

    private Course course;
    [DataMember]
    public Course Course
    {
      get { return course; }
      set
      {
        if (!object.Equals(course, value))
        {
          course = value;
          OnPropertyChanged("Course");
        }
      }
    }
  }

}
