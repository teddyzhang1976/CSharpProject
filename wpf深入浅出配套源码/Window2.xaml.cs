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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            //this.textBox2.SetBinding(TextBox.TextProperty, new Binding("Text.Length") {Source = textBox1, Mode= BindingMode.OneWay });
            this.textBox2.SetBinding(TextBox.TextProperty, new Binding("Text.[3]") { Source=textBox1,Mode= BindingMode.OneWay});
        }
    }
}
