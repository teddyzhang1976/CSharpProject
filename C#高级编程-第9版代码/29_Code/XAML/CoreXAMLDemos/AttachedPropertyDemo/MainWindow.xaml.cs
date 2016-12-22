using System;
using System.Windows;

namespace Wrox.ProCSharp.XAML
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      MyAttachedPropertyProvider.SetMyProperty(button1, 44);

      foreach (object item in LogicalTreeHelper.GetChildren(grid1))
      {
        FrameworkElement e = item as FrameworkElement;
        if (e != null)
          list1.Items.Add(String.Format("{0}: {1}", e.Name, MyAttachedPropertyProvider.GetMyProperty(e)));
      }
    }
  }
}
