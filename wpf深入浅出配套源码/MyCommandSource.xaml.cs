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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MyCommandSource.xaml 的交互逻辑
    /// </summary>
    public partial class MyCommandSource : UserControl,ICommandSource
    {
        
        /// <summary>
        /// 继承自ICommand的3个属性
        /// </summary>
        public ICommand Command
        {
            get;
            set;
        }

        public object CommandParameter
        {
            get;
            set;
        }

        public IInputElement CommandTarget
        {
            get;
            set;
        }
        //在命令目标上执行命令，或者说让命令作用于命令目标
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if(this.CommandTarget!=null)
            {
                this.Command.Execute(CommandTarget);
            }
        }
    }
}
