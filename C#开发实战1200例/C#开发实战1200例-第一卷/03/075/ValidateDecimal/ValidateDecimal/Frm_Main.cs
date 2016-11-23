using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateDecimal
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsDecimal(txt_Value.Text.Trim()))//验证小数是否正确
            { MessageBox.Show("请输入两位小数!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证小数是否正确
        /// </summary>
        /// <param name="str_decimal">小数字符串</param>
        /// <returns>返回布尔值</returns>
        public bool IsDecimal(string str_decimal)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_decimal, @"^[0-9]+(.[0-9]{2})?$");
        }
    }
}