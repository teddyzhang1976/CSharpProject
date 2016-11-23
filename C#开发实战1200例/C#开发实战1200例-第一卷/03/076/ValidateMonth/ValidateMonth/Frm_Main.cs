using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateMonth
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsMonth(textBox1.Text.Trim()))//验证月份是否正确
            { MessageBox.Show("输入月份不正确!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证月份是否正确
        /// </summary>
        /// <param name="str_Month">月份信息字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsMonth(string str_Month)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_Month, @"^(0?[[1-9]|1[0-2])$");
        }
    }
}