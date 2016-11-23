using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToUpperOrLower
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (rbtn_upper.Checked)//判断字符串转换为大写或小写
            {
                txt_changed.Text = //将字符串转换为大写
                    txt_string.Text.ToUpper();
            }
            else
            {
                txt_changed.Text = //将字符串转换为小写
                    txt_string.Text.ToLower();
            }
        }

        private void txt_string_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_string.Text == "          请输入字符串")
            {
                txt_string.Text = //清空TextBox控件中的文本信息
                    string.Empty;
            }
        }
    }
}
