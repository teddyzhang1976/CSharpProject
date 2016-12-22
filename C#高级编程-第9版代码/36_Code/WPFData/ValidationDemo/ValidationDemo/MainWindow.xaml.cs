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

namespace ValidationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SomeData p1 = new SomeData { Value1 = 11 };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = p1;
        }

        private void OnShowValue(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(p1.Value1.ToString());
        }

        private void OnShowNotification(object sender, RoutedEventArgs e)
        {
          var win = new NotificationWindow();
          win.ShowDialog();
        }

    }
}
