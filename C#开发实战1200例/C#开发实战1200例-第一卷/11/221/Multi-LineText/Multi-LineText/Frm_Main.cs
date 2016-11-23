using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multi_LineText
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            txt_Change.Location = new Point(0, 0);//设置文本框位置
            txt_Change.Multiline = true;//设置文本框显示多行
            txt_Change.Width = //设置文本框宽度
                this.Width;
            txt_Change.Height = //设置文本框高度
                ClientRectangle.Height - btn_OK.Height-15;
        }
    }
}
