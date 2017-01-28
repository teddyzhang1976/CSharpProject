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
    /// Window29.xaml 的交互逻辑
    /// </summary>
    public partial class Window29 : Window
    {
        public Window29()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //路由终止，提高系统性能
            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter.ToString() == "Student")
            {
                this.lbInfos.Items.Add(string.Format("New Student:{0} 好好学习，天天向上。",txtName.Text));
            }
            else if(e.Parameter.ToString()=="Teacher")
            {
                this.lbInfos.Items.Add(string.Format("New Teacher:{0} 学而不厌，诲人不倦。", txtName.Text));
            }
            //路由终止，提高系统性能
            e.Handled = true;
        }
    }
}
