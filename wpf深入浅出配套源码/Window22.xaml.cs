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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Window22.xaml 的交互逻辑
    /// </summary>
    public partial class Window22 : Window
    {
        public Window22()
        {
            InitializeComponent();
            rt.SetBinding(Canvas.LeftProperty, new Binding("Value") { Source=slider1});
            rt.SetBinding(Canvas.TopProperty, new Binding("Value") { Source = slider2});
        }
    }
}
