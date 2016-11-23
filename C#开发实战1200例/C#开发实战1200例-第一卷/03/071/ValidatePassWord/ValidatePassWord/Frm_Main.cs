using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePassWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPassword(textBox1.Text.Trim()))//验证密码格式是否正确
            { MessageBox.Show("密码格式不正确!!!"); }//弹出消息对话框
            else { MessageBox.Show("密码格式正确!!!!!"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证码码输入条件
        /// </summary>
        /// <param name="str_password">密码字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsPassword(string str_password)
        {
            return System.Text.RegularExpressions.//使用正则表达式判断是否匹配
                Regex.IsMatch(str_password, @"[A-Za-z]+[0-9]");
        }
    }
}