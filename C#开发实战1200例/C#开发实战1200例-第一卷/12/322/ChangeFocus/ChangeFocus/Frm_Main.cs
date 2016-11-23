using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChangeFocus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        // 回车切换控件焦点//要想使这个方法起到作用先将窗体的keypreview属性改为true
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//判断是否按下回车键
            {
                this.SelectNextControl(//激活下一个控件
                    this.ActiveControl, true, true, true, true);
            }
            base.OnKeyPress(e);//调用基类的OnKeyPress方法
        }
    }
}
