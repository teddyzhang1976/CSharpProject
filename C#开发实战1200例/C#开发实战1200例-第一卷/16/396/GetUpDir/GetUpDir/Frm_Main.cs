using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GetUpDir
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();//创建FolderBrowserDialog对象
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                textBox1.Text = FBDialog.SelectedPath;//显示选择的文件夹
                string str1 = textBox1.Text;//记录选择的文件夹
                string str2 = Directory.GetParent(str1).FullName;//获取上级目录的全名
                string myInfo = "当前目录是：" + str1;//显示当前文件夹
                myInfo += "\n上级目录是：" + str2;//显示上级文件夹
                label2.Text = myInfo;
            }
        }
    }
}