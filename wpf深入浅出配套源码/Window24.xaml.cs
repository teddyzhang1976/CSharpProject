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
    /// Window24.xaml 的交互逻辑
    /// </summary>
    public partial class Window24 : Window
    {
        public Window24()
        {
            InitializeComponent();
            this.gridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
           
        }

        

        private void Button_Click(object obj, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
        }
    }
}
