using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReplaceStr
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strResult = System.Text.RegularExpressions.Regex.//使用正则表达式替换字符串
                Replace(textBox1.Text, @"[A-Za-z]\*?", textBox2.Text);
            MessageBox.Show("替换前字符:" + "\n" + textBox1.Text +//弹出消息对话框
                "\n" + "替换的字符:" + "\n" + textBox2.Text + "\n" +
                "替换后的字符:" + "\n" + strResult,"替换");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();//关闭窗体
        }
    }
}