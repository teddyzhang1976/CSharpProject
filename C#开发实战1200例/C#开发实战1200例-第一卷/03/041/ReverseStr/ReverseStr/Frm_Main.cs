using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReverseStr
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            char[] P_chr=txt_input.Text.ToCharArray();//从字符串中得到字节数组
            Array.Reverse(P_chr, 0, txt_input.Text.Length);//反转字节数组
            txt_output.Text = //将字节数组转换为字符串并输出
                new StringBuilder().Append(P_chr).ToString();
        }
    }
}
