using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetShortPathName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("Kernel32.dll")]//声明API函数
        private static extern Int16 GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, Int16 cchBuffer);

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();//创建OpenFileDialog对象
            if (OFDialog.ShowDialog() == DialogResult.OK)//判读是否选择了文件
            {
                textBox1.Text = OFDialog.FileName;//显示选择的文件名
                string longName = textBox1.Text;//记录选择的文件名
                StringBuilder shortName = new System.Text.StringBuilder(256);//创建StringBuilder对象
                GetShortPathName(longName, shortName, 256);//调用API函数转换成短文件名
                string myInfo = "长文件名：" + longName;//显示长文件名
                myInfo += "\n短文件名：" + shortName;//显示短文件名
                label2.Text = myInfo;
            }
        }
    }
}