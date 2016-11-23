using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShieldPaste
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            TextBoxx tb = new TextBoxx();//创建文本框对象
            tb.Width = Width;//设置文本框宽度
            tb.Height = Height;//设置文本框高度
            tb.Location = new Point(0, 0);//设置文本框起始位置
            tb.Multiline = true;//设置文本框为多行
            Controls.Add(tb);//将文本框添加到控件集合
        }
    }
    class TextBoxx : TextBox
    {
        public const int WM_PASTE = 0x0302;//粘贴消息信息
        protected override void WndProc(ref Message m)//重写处理消息方法
        {
            if (m.Msg != WM_PASTE)//屏蔽粘贴消息信息
            {
                base.WndProc(ref m);//调用基类消息处理方法
            }
        }
    }
}
