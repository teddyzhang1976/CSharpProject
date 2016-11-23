using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnderLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_Str.Text = string.Format(//设置文本框中的文字
                "C#编程词典{0}{0}C#编程宝典{0}{0}C#范例宝典{0}{0}C#实战宝典",
                Environment.NewLine);
        }

        private void btn_DisplayUnderLine_Click(object sender, EventArgs e)
        {
            txt_Str.Font = //设置文本框中文字字体
                new Font(new Font("宋体",15), FontStyle.Underline);
        }
    }
}
