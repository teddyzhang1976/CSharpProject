using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidatePerson
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsIDcard(textBox1.Text.Trim()))//验证身份证号是否正确
            { MessageBox.Show("身份证号不正确!!!"); }//弹出消息对话框
            else { MessageBox.Show("身份证号正确!!!!!"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证身份证号是否正确
        /// </summary>
        /// <param name="str_idcard">身份证号字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }
    }
}