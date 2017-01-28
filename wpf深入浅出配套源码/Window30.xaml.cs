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
using WpfApplication1.Command;

namespace WpfApplication1
{
    /// <summary>
    /// Window30.xaml 的交互逻辑
    /// </summary>
    public partial class Window30 : Window
    {
        public Window30()
        {
            InitializeComponent();
            ClearCommand clearCommand = new ClearCommand();
            this.myCommandSource1.Command = clearCommand;
            this.myCommandSource1.CommandTarget = mniView1;
        }
    }
}
