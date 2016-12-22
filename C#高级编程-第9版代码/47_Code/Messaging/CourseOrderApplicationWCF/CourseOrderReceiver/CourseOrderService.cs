using System;
using System.ServiceModel;

namespace Wrox.ProCSharp.Messaging
{
  [ServiceBehavior(UseSynchronizationContext=true)]
  public class CourseOrderService : ICourseOrderService
  {
    public static event EventHandler<CourseOrderEventArgs> CourseOrderAdded;

    public void AddCourseOrder(CourseOrder courseOrder)
    {
      var courseOrderAdded = CourseOrderAdded;
      if (courseOrderAdded != null)
      {
        courseOrderAdded(this, new CourseOrderEventArgs(courseOrder));
      }
    }
  }
}
