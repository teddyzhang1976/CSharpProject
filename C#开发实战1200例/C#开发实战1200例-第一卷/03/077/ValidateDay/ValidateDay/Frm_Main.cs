using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateDay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsDay(textBox1.Text.Trim()))//验证每月的31天
            { MessageBox.Show("输入天数不正确!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证每月的31天
        /// </summary>
        /// <param name="str_day">每月的天数</param>
        /// <returns>返回布尔值</returns>
        public bool IsDay(string str_day)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_day, @"^((0?[1-9])|((1|2)[0-9])|30|31)$");
        }
    }
}