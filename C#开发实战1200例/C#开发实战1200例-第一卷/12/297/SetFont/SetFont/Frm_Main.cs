using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetFont
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog();//弹出字体选择对话框
            this.textBox1.Font = //设置文字字体
                this.fontDialog1.Font;
        }
    }
}