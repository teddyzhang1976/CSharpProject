using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication1.InterFace;

namespace WpfApplication1.Command
{
    /// <summary>
    ///自定义命令
    /// </summary>
    public class ClearCommand:ICommand
    {
        //用来判断命令是否可以执行
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        //当命令可执行状态发送改变时，应当被激发
        public event EventHandler CanExecuteChanged;

        //命令执行时，带有与业务相关的Clear逻辑
        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if(view!=null)
            {
                view.Clear();
            }
        }
    }
}
