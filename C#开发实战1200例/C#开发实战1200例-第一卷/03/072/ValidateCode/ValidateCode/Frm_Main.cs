using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateCode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsPostalcode(textBox1.Text))//验证邮编格式是否正确
            { MessageBox.Show("邮政编号不正确!!!"); }//弹出消息对话框
            else { MessageBox.Show("邮政编号正确!!!!!"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证邮编格式是否正确
        /// </summary>
        /// <param name="str_postalcode">邮编字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.//使用正则表达式判断是否匹配
                Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
    }
}