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
    /// Window15.xaml 的交互逻辑
    /// </summary>
    public partial class Window15 : Window
    {
        public Window15()
        {
            InitializeComponent();

            RelativeSource rs = new RelativeSource(RelativeSourceMode.Self);
           
            Binding bind = new Binding("Name") { RelativeSource = rs };
            this.textBox1.SetBinding(TextBox.TextProperty, bind);
        }
    }
}
