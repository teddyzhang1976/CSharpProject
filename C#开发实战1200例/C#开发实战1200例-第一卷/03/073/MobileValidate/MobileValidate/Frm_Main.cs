using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobileValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsHandset(textBox1.Text))//验证手机号是否正确
            { MessageBox.Show("手机号不正确!!!"); }//弹出消息对话框
            else { MessageBox.Show("手机号正确!!!!!"); }//弹出消息对话框
            
        }

        /// <summary>
        /// 验证手机号是否正确
        /// </summary>
        /// <param name="str_handset">手机号码字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.////使用正则表达式判断是否匹配
                IsMatch(str_handset, @"^[1]+[3,5]+\d{9}$");
        }
    }
}