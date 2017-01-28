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
    /// Window27.xaml 的交互逻辑
    /// </summary>
    public partial class Window27 : Window
    {
        public Window27()
        {
            InitializeComponent();
            //为外层Grid添加路由事件
            Person.AddNameChangedHandle(this.gd_main, new RoutedEventHandler(PersonNameChanged));
        }


        private void PersonNameChanged(object obj, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Person).Name);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Person persion = new Person();
            persion.Id = 0;
            persion.Name = "Darren";
            //准备事件消息并发送路由事件
            RoutedEventArgs arg = new RoutedEventArgs(Person.NameChangedEvent, persion);
            this.button1.RaiseEvent(arg);
        }
    }
}
