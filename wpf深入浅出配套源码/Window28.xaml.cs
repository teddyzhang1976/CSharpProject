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
    /// Window28.xaml 的交互逻辑
    /// </summary>
    public partial class Window28 : Window
    {
        public Window28()
        {
            InitializeComponent();
            InitializeCommand();
        }
        //声明并定义命令
        private RoutedCommand rouutedCommand = new RoutedCommand("Clear",typeof(Window28));
        private void InitializeCommand()
        {
            //把命令赋值给命令源,并定义快捷键
            this.btn1.Command = rouutedCommand;
            this.rouutedCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            //指定命令目标
            this.btn1.CommandTarget = txtA;

            //创建命令关联
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = rouutedCommand;//只关注与rouutedCommand相关的命令
            commandBinding.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            commandBinding.Executed += new ExecutedRoutedEventHandler(cb_Execute);
            //把命令关联安置在外围控件上
            this.sp1.CommandBindings.Add(commandBinding);
        }
        //当命令到达目标之后，此方法被调用
        private void cb_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            txtA.Clear();
            //避免事件继续向上传递而降低程序性能
            e.Handled = true;
        }
        //当探测命令是否可执行的时候该方法会被调用
        private void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtA.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //避免事件继续向上传递而降低程序性能
            e.Handled = true;
        }

    }
}
