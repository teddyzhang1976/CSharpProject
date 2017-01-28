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
using WpfApplication1.Model;

namespace WpfApplication1
{
    /// <summary>
    /// Window25.xaml 的交互逻辑
    /// </summary>
    public partial class Window25 : Window
    {
        public Window25()
        {
            InitializeComponent();
        }

        public void ReportTimeHandle(object sender,ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = string.Format("{0}到达{1}",timeStr,element.Name);
            this.lb_view.Items.Add(content);
            if(element==gd_2)
            {
                e.Handled = true;
            }
        }
    }
}
