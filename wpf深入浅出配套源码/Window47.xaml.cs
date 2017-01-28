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
    /// Window47.xaml 的交互逻辑
    /// </summary>
    public partial class Window47 : Window
    {
        public Window47()
        {
            InitializeComponent();
        }

        double o = 1;//不透明度指数
        private void btnReal_Click(object sender, RoutedEventArgs e)
        {
            VisualBrush vb = new VisualBrush(this.btnReal);
            Rectangle rtg = new Rectangle();
            rtg.Width = btnReal.Width;
            rtg.Height = btnReal.Height;
            rtg.Fill = vb;
            rtg.Opacity = o;
            o -= 0.2;
            this.spRight.Children.Add(rtg);
        }
    }
}
