using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OpenFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt文件(*.txt)|*.txt";//筛选文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//弹出打开文件对话框
            {
                System.IO.StreamReader sr = new//创建文件读取器对象
                   System.IO.StreamReader(openFileDialog1.FileName,Encoding.Default);
                textBox1.Text = sr.ReadToEnd();//显示文本文件内容
                sr.Close();//关闭流
            }
        }
    }
}