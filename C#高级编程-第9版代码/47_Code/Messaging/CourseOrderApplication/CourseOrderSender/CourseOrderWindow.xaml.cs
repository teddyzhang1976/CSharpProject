using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Messaging;
using System.Windows;

namespace Wrox.ProCSharp.Messaging
{
  public partial class CourseOrderWindow : Window
  {
    private readonly ObservableCollection<string> courseList = new ObservableCollection<string>();
    private readonly CourseOrder courseOrder = new CourseOrder();
    private readonly MessageConfiguration messageConfiguration = new MessageConfiguration();

    public CourseOrderWindow()
    {
      InitializeComponent();
      FillCourses();
      this.DataContext = this;
    }

    public IEnumerable<string> Courses
    {
      get
      {
        return courseList;
      }
    }

    private void FillCourses()
    {
      courseList.Add("Parallel .NET Programming");
      courseList.Add("Data Access with the ADO.NET Entity Framework");
      courseList.Add("Distributed Solutions with WCF");
      courseList.Add("Windows 8 Metro Apps with XAML and C#");
    }

    public CourseOrder CourseOrder
    {
      get
      {
        return courseOrder;
      }
    }
    public MessageConfiguration MessageConfiguration
    {
      get
      {
        return messageConfiguration;
      }
    }

    private void buttonSubmit_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        using (var queue = new MessageQueue(CourseOrder.CourseOrderQueueName))
        using (var message = new Message(courseOrder)
          {
            Recoverable = true,
            Priority = MessageConfiguration.HighPriority == true ? MessagePriority.High : MessagePriority.Normal
          })
        {
          queue.Send(message, String.Format("Course Order {{{0}}}", courseOrder.Customer.Company));
        }

        MessageBox.Show("Course Order submitted", "Course Order",
              MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (MessageQueueException ex)
      {
        MessageBox.Show(ex.Message, "Course Order Error",
              MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
