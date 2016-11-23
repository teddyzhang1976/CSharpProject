using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateSplit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Split_Click(object sender, EventArgs e)
        {
            string[] P_Str = System.Text.RegularExpressions.//使用正则表达式根据数字进行拆分
                Regex.Split(txt_Split.Text, "[1-9]");
            foreach (string s in P_Str)//遍历拆分后的字符串集合
            {
                txt_Result.Text += s;//显示字符串
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出应用程序
        }
    }
}