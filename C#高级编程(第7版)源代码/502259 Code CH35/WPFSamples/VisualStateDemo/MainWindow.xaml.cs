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

namespace VisualStateDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSleeping(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(button1, "Sleeping", true);
        }

        private void OnPlaying(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(button1, "Playing", true);
        }

        private void OnCrying(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(button1, "Crying", true);
        }
    }
}
