using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Messaging;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Wrox.ProCSharp.Messaging
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CourseOrderReceiverWindow : Window
    {
        private MessageQueue orderQueue;

        public CourseOrderReceiverWindow()
        {
            InitializeComponent();

            //string queueName =
            //      "FormatName:Public=D99CE5F3–4282–4a97–93EE-E9558B15EB13";
            string queueName = CourseOrder.CourseOrderQueueName;
            // string queueName = @".\Private$\CourseOrder";

            orderQueue = new MessageQueue(queueName);

            orderQueue.Formatter = new XmlMessageFormatter(
                new Type[]
                {
                    typeof(CourseOrder),
                    typeof(Customer),
                    typeof(Course)
                });

            // start the task that fills the ListBox with orders
            Task t1 = new Task(PeekMessages);
            t1.Start();
        }

        private void PeekMessages()
        {
            using (MessageEnumerator messagesEnumerator =
                  orderQueue.GetMessageEnumerator2())
            {
                while (messagesEnumerator.MoveNext(TimeSpan.FromHours(3)))
                {
                    var labelId = new LabelIdMapping()
                    {
                        Id = messagesEnumerator.Current.Id,
                        Label = messagesEnumerator.Current.Label
                    };
                    Dispatcher.Invoke(DispatcherPriority.Normal,
                          new Action<LabelIdMapping>(AddListItem), labelId);
                }
            }
            MessageBox.Show("No orders in the last 3 hours. Exiting thread",
                  "Course Order Receiver", MessageBoxButton.OK,
                  MessageBoxImage.Information);
        }

        private void AddListItem(LabelIdMapping labelIdMapping)
        {
            listOrders.Items.Add(labelIdMapping);
        }

        private void listOrders_SelectionChanged(object sender, RoutedEventArgs e)
        {
            LabelIdMapping labelId = listOrders.SelectedItem as LabelIdMapping;
            if (labelId == null)
                return;

            orderQueue.MessageReadPropertyFilter.Priority = true;
            Message message = orderQueue.PeekById(labelId.Id);

            CourseOrder order = message.Body as CourseOrder;
            if (order != null)
            {
                textCourse.Text = order.Course.Title;
                textCompany.Text = order.Customer.Company;
                textContact.Text = order.Customer.Contact;
                buttonProcessOrder.IsEnabled = true;

                if (message.Priority > MessagePriority.Normal)
                {
                    labelPriority.Visibility = Visibility.Visible;
                }
                else
                {
                    labelPriority.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MessageBox.Show("The selected item is not a course order",
                      "Course Order Receiver", MessageBoxButton.OK,
                      MessageBoxImage.Warning);
            }
        }

        private void buttonProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            LabelIdMapping labelId = listOrders.SelectedItem as LabelIdMapping;
            Message message = orderQueue.ReceiveById(labelId.Id);

            listOrders.Items.Remove(labelId);
            listOrders.SelectedIndex = -1;
            buttonProcessOrder.IsEnabled = false;
            textCompany.Text = string.Empty;
            textContact.Text = string.Empty;
            textCourse.Text = string.Empty;

            MessageBox.Show("Course order processed", "Course Order Receiver",
                  MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private class LabelIdMapping
        {
            public string Label { get; set; }
            public string Id { get; set; }

            public override string ToString()
            {
                return Label;
            }
        }

    }



}
