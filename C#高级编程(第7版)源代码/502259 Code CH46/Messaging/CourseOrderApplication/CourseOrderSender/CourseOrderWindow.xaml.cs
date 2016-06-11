using System;
using System.Messaging;
using System.Windows;

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

             // using (MessageQueue queue = new MessageQueue(@".\Private$\CourseOrder"))
             using (MessageQueue queue = new MessageQueue(
                 CourseOrder.CourseOrderQueueName))
            using (var message = new Message(order))
            {
               if (checkBoxPriority.IsChecked == true)
               {
                  message.Priority = MessagePriority.High;
               }
               message.Recoverable = true;
               queue.Send(message,  String.Format("Course Order {{{0}}}",
                     order.Customer.Company));
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
