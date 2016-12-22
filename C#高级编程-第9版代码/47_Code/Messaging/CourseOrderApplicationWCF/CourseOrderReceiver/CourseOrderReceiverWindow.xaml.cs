using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;

namespace Wrox.ProCSharp.Messaging
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class CourseOrderReceiverWindow : Window
  {
    private ObservableCollection<CourseOrder> courseOrders = new ObservableCollection<CourseOrder>();
//     private object syncOrdersList = new object();


    public CourseOrderReceiverWindow()
    {
      InitializeComponent();
      this.DataContext = courseOrders;
      CourseOrderService.CourseOrderAdded += (sender, e) =>
        {
          courseOrders.Add(e.CourseOrder);
          buttonProcessOrder.IsEnabled = true;
        };

      var host = new ServiceHost(typeof(CourseOrderService));
      try
      {
        host.Open();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }



  

    private void buttonProcessOrder_Click(object sender, RoutedEventArgs e)
    {
      var courseOrder = listOrders.SelectedItem as CourseOrder;
      courseOrders.Remove(courseOrder);
      listOrders.SelectedIndex = -1;
      buttonProcessOrder.IsEnabled = false;

      MessageBox.Show("Course order processed", "Course Order Receiver",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
