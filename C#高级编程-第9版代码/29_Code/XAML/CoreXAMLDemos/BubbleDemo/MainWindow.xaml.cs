using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace BubbleDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private ObservableCollection<string> messages = new ObservableCollection<string>();
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = messages;
    }

    private void AddMessage(string message, object sender, RoutedEventArgs e)
    {
      messages.Add(String.Format("{0}, sender: {1}; source: {2}; original source: {3}",
          message, (sender as FrameworkElement).Name,
          (e.Source as FrameworkElement).Name,
          (e.OriginalSource as FrameworkElement).Name));
    }

    private void OnOuterButtonClick(object sender, RoutedEventArgs e)
    {
      AddMessage("outer event", sender, e);
    }

    private void OnInner1(object sender, RoutedEventArgs e)
    {
      AddMessage("inner1", sender, e);
    }

    private void OnInner2(object sender, RoutedEventArgs e)
    {
      AddMessage("inner2", sender, e);

      e.Handled = true;
    }

    private void OnButton2(object sender, RoutedEventArgs e)
    {
      AddMessage("button2", sender, e);
      e.Source = sender;
    }


  }
}
