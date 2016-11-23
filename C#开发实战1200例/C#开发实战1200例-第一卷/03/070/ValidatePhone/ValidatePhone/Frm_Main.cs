using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePhone
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsTelephone(textBox1.Text))//验证电话号码格式是否正确
            { MessageBox.Show("电话号码格式不正确"); }//弹出消息对话框
            else { MessageBox.Show("电话号码格式正确"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证电话号码格式是否正确
        /// </summary>
        /// <param name="str_telephone">电话号码信息</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.//使用正则表达式判断是否匹配
                Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
    }
}