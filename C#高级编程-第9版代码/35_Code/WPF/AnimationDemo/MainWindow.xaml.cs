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

namespace AnimationDemo
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

        private void OnEllipseAnimation(object sender, RoutedEventArgs e)
        {
            new EllipseWindow().Show();
        }

        private void OnButtonAnimation(object sender, RoutedEventArgs e)
        {
            new ButtonAnimationWindow().Show();
        }

        private void OnKeyframeAnimation(object sender, RoutedEventArgs e)
        {
            new KeyFrameWindow().Show();
        }

        private void OnEventTrigger(object sender, RoutedEventArgs e)
        {
            new EventTriggerWindow().Show();
        }
    }
}
