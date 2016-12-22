using System;

namespace Wrox.ProCSharp.Messaging
{
  public class CourseOrderEventArgs : EventArgs
  {
    public CourseOrderEventArgs(CourseOrder courseOrder)
    {
      this.CourseOrder = courseOrder;
    }
    public CourseOrder CourseOrder { get; private set; }
  }
}
