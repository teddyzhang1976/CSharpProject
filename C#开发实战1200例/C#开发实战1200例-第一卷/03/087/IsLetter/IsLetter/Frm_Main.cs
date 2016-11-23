using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IsLetter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsLetter(textBox1.Text.Trim()))//验证字符串是否为大小写字母组成
            { MessageBox.Show("输入的不是字母!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入的是字母!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证字符串是否为大小写字母组成
        /// </summary>
        /// <param name="str_Letter">字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsLetter(string str_Letter)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_Letter, @"^[A-Za-z]+$");
        }
    }
}