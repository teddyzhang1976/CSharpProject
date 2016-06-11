using System;
using System.Collections.ObjectModel;
using System.Messaging;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Wrox.ProCSharp.Messaging
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CourseOrderReceiverWindow : Window
    {
        private ObservableCollection<CourseOrder> courseOrders =
            new ObservableCollection<CourseOrder>();


        public CourseOrderReceiverWindow()
        {
            InitializeComponent();

            CourseOrderService.CourseOrderAdded +=
                (sender, e) =>
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

            this.DataContext = courseOrders;

        }

  
        private void buttonProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            CourseOrder courseOrder = listOrders.SelectedItem as CourseOrder;
            courseOrders.Remove(courseOrder);
            listOrders.SelectedIndex = -1;
            buttonProcessOrder.IsEnabled = false;

            MessageBox.Show("Course order processed", "Course Order Receiver",
               MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }



}
