using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateInteger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsIntNumber(textBox1.Text.Trim()))//验证输入是否为非零负整数
            { MessageBox.Show("只充许输入非零的负整数!!!", "提示"); }//弹出消息对话框
            else { MessageBox.Show("输入信息正确!!!!!", "提示"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证输入是否为非零负整数
        /// </summary>
        /// <param name="str_intNumber">用户输入的数值</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsIntNumber(string str_intNumber)
        {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_intNumber, @"^\-[1-9][0-9]*$");
        }
    }
}