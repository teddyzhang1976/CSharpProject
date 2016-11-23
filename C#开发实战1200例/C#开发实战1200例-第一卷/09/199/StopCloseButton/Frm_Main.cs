using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StopCloseButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;//定义将要截获的消息类型
            const int SC_CLOSE = 0xF060;//定义关闭按钮对应的消息值
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_CLOSE))//当鼠标单击关闭按钮时
            {
                return;//直接返回，不进行处理
            }
            base.WndProc(ref m);//传递下一条消息
        }

        private void ExitProgram_Click(object sender,EventArgs e)
        {
            Application.Exit();//退出应用程序
        }
    }
}
