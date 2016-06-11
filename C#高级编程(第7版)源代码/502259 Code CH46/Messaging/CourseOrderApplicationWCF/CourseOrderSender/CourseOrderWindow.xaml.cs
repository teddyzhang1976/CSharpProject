using System;
using System.Messaging;
using System.Windows;
using System.ServiceModel;

namespace Wrox.ProCSharp.Messaging
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CourseOrderWindow : Window
    {
        public CourseOrderWindow()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = new CourseOrder
                {
                    Course = new Course()
                    {
                        Title = comboBoxCourses.Text
                    },
                    Customer = new Customer
                    {
                        Company = textCompany.Text,
                        Contact = textContact.Text
                    }
                };

                var factory = new ChannelFactory<ICourseOrderService>("queueEndpoint");
                ICourseOrderService proxy = factory.CreateChannel();
                proxy.AddCourseOrder(order);
                factory.Close();

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
