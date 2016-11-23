using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LetterCount
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsLength(textBox1.Text.Trim()))//验证输入字符串中的字符数量是否大于7个
            { MessageBox.Show("至少输入8个字符!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证输入字符串中的字符数量是否大于7个
        /// </summary>
        /// <param name="str_Length">字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsLength(string str_Length)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_Length, @"^.{8,}$");
        }
    }
}