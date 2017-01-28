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
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            List<string> infos = new List<string>() { "Jim","Darren","Jacky"};
            textBox1.SetBinding(TextBox.TextProperty, new Binding("/") { Source=infos});
            textBox2.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = infos, Mode= BindingMode.OneWay });
            textBox3.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = infos, Mode= BindingMode.OneWay });

        }
    }
}
