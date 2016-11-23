using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ValidateLength
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPasswLength(textBox1.Text.Trim()))//验证密码长度是否正确
            { MessageBox.Show("密码长度不正确\n" +//弹出消息对话框
                "密码长度为6-18位!!!", "提示"); }
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证密码长度是否正确
        /// </summary>
        /// <param name="str_Length">密码字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsPasswLength(string str_Length)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_Length, @"^\d{6,18}$");
        }
    }
}