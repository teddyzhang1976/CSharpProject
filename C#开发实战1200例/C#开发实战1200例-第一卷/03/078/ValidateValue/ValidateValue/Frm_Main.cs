using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateValue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsNumber(textBox1.Text.Trim()))//验证输入是否为数字
            { MessageBox.Show("只充许输入数字!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证输入是否为数字
        /// </summary>
        /// <param name="str_number">用户输入的字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_number, @"^[0-9]*$");
        }
    }
}