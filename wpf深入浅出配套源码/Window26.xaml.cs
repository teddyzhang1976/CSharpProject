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
    /// Window26.xaml 的交互逻辑
    /// </summary>
    public partial class Window26 : Window
    {
        public Window26()
        {
            InitializeComponent();
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonClick));
        }

        private void ButtonClick(object sender,RoutedEventArgs e)
        {
            string originSource = string.Format("VisualTree StartPoint:{0},type is {1}",(e.OriginalSource as FrameworkElement).Name,e.OriginalSource.GetType().Name);

            string stringSource = string.Format("LogicTree startPoint:{0},Type is {1}",(e.Source as FrameworkElement).Name,e.Source.GetType().Name);
            MessageBox.Show(originSource+"\r\n"+stringSource);
        }
    }
}
