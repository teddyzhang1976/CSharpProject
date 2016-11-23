using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Text = "";//设置标题栏文本为空
            ControlBox = false;//不在窗体标题栏中显示控件
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
