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
using WpfApplication1.InterFace;

namespace WpfApplication1
{
    /// <summary>
    /// MniView.xaml 的交互逻辑
    /// </summary>
    public partial class MniView : UserControl,IView
    {
        //构造器
        public MniView()
        {
            InitializeComponent();
        }
        //继承自IView的成员们
        public bool IsChanged
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetBinding()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 用于清除内容的业务逻辑
        /// </summary>
        public void Clear()
        {
            this.txt1.Clear();
            this.txt2.Clear();
            this.txt3.Clear();
            this.txt4.Clear();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
