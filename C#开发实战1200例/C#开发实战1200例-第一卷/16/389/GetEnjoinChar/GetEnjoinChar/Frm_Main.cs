using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetEnjoinChar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;//清空文本框
            char[] myChars = Path.GetInvalidPathChars();//创建字符串数组
            String myInfo = string.Empty;//定义空字符串
            foreach (char myChar in myChars)//遍历字符数组
            {
                myInfo += myChar.ToString() + "\n";//获取字符数组中的项
            }
            richTextBox1.Text = myInfo;//显示禁用的所有字符
        }
    }
}