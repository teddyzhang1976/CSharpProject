using System;
using System.Collections.ObjectModel;
using System.Messaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Wrox.ProCSharp.Messaging
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class CourseOrderReceiverWindow : Window
  {
    private MessageQueue ordersQueue;
    private ObservableCollection<MessageInfo> ordersList = new ObservableCollection<MessageInfo>();
    private object syncOrdersList = new object();

    public ObservableCollection<MessageInfo> OrdersList
    {
      get
      {
        return ordersList;
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      if (ordersQueue != null)
        ordersQueue.Dispose();
    }

    public CourseOrderReceiverWindow()
    {
      InitializeComponent();
      this.DataContext = this;
      BindingOperations.EnableCollectionSynchronization(ordersList, syncOrdersList);

      ordersQueue = new MessageQueue(CourseOrder.CourseOrderQueueName);

      ordersQueue.Formatter = new XmlMessageFormatter(
        new Type[]
          {
            typeof(CourseOrder),
            typeof(Customer),
            typeof(Course)
          });

      // start the task that fills the ListBox with orders  
      Task.Factory.StartNew(PeekMessages);
    }

    private void PeekMessages()
    {
      try
      {
        using (MessageEnumerator messagesEnumerator = ordersQueue.GetMessageEnumerator2())
        {
          while (messagesEnumerator.MoveNext(TimeSpan.FromHours(3)))
          {
            var messageInfo = new MessageInfo
            {
              Id = messagesEnumerator.Current.Id,
              Label = messagesEnumerator.Current.Label
            };

            ordersList.Add(messageInfo);
          }
        }
        MessageBox.Show("No orders in the last 3 hours. Exiting thread",
              "Course Order Receiver", MessageBoxButton.OK,
              MessageBoxImage.Information);
      }
      catch (MessageQueueException ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }


    private void listOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var messageInfo = (sender as ListBox).SelectedItem as MessageInfo;
      if (messageInfo == null)
        return;

      ordersQueue.MessageReadPropertyFilter.Priority = true;
      Message message = ordersQueue.PeekById(messageInfo.Id);

      var order = message.Body as CourseOrder;
      if (order != null)
      {
        selectedCourseInfo.MessageInfo = messageInfo;
        selectedCourseInfo.Course = order.Course.Title;
        selectedCourseInfo.Company = order.Customer.Company;
        selectedCourseInfo.Contact = order.Customer.Contact;
        selectedCourseInfo.EnableProcessing = true;

        if (message.Priority > MessagePriority.Normal)
        {
          selectedCourseInfo.HighPriority = Visibility.Visible;
        }
        else
        {
          selectedCourseInfo.HighPriority = Visibility.Hidden;
        }
      }
      else
      {
        MessageBox.Show("The selected item is not a course order",
              "Course Order Receiver", MessageBoxButton.OK,
              MessageBoxImage.Warning);
      }
    }

    private readonly CourseOrderInfo selectedCourseInfo = new CourseOrderInfo();

    public CourseOrderInfo SelectedCourseInfo
    {
      get { return selectedCourseInfo; }
    }
    

    private void buttonProcessOrder_Click(object sender, RoutedEventArgs e)
    {
      Message message = ordersQueue.ReceiveById(SelectedCourseInfo.MessageInfo.Id);

      ordersList.Remove(SelectedCourseInfo.MessageInfo);

      listOrders.SelectedIndex = -1;
      selectedCourseInfo.Clear();

      MessageBox.Show("Course order processed", "Course Order Receiver",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
