using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IsChinese
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsChinese(textBox1.Text.Trim()))//验证字符串是否为汉字
            { MessageBox.Show("输入的不是中文!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证字符串是否为汉字
        /// </summary>
        /// <param name="str_chinese">字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsChinese(string str_chinese)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_chinese, @"^[\u4e00-\u9fa5],{0,}$");
        }
    }
}