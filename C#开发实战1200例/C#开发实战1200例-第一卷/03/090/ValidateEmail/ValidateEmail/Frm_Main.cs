using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateEmail
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsEmail(textBox1.Text))//验证Email格式是否正确
            { MessageBox.Show("Email格式错误！"); }//弹出消息对话框
            else { MessageBox.Show("Email格式正确！"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证Email格式是否正确
        /// </summary>
        /// <param name="str_Email">Email地址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email,//使用正则表达式判断是否匹配
@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}