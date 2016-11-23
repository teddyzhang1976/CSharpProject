using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateCapitalLetter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsUpChar(textBox1.Text.Trim()))//验证输入字符是否为大写字母
            { MessageBox.Show("只充许输入大写字母!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证输入字符是否为大写字母
        /// </summary>
        /// <param name="str_UpChar">用户输入的字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsUpChar(string str_UpChar)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_UpChar, @"^[A-Z]+$");
        }
    }
}