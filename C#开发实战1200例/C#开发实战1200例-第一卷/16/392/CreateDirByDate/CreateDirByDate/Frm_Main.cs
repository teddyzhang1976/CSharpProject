using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateDirByDate
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
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择文件夹
            {
                string strPath = FBDialog.SelectedPath;//记录选择的文件夹
                if (strPath.EndsWith("\\"))
                    textBox1.Text = strPath;//显示选择的文件夹
                else
                    textBox1.Text = strPath + "\\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strName = DateTime.Now.ToString("yyyyMMddhhmmss");//对当前日期进行格式化
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text + strName);//创建DirectoryInfo对象
            DInfo.Create();//创建文件夹
            MessageBox.Show("文件夹创建成功，名称为" + strName + "");
        }
    }
}