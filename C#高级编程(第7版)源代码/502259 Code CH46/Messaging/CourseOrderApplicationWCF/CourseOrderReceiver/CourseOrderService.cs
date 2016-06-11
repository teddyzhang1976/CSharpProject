using System;
using System.ServiceModel;

namespace Wrox.ProCSharp.Messaging
{
    [ServiceBehavior(UseSynchronizationContext = true)]
    public class CourseOrderService : ICourseOrderService
    {
        public static event EventHandler<CourseOrderEventArgs> CourseOrderAdded;

        public void AddCourseOrder(CourseOrder courseOrder)
        {
            if (CourseOrderAdded != null)
                CourseOrderAdded(this, new CourseOrderEventArgs(courseOrder));
        }
    }

    public class CourseOrderEventArgs : EventArgs
    {
        public CourseOrderEventArgs(CourseOrder courseOrder)
        {
            this.CourseOrder = courseOrder;
        }
        public CourseOrder CourseOrder { get; private set; }
    }

}
