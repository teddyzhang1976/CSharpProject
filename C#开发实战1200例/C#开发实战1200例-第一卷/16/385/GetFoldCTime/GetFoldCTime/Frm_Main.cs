using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetFoldCTime
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
                textBox1.Text = strPath;//显示选择的文件夹
                DirectoryInfo DInfo = new DirectoryInfo(strPath);//创建DirectoryInfo对象
                label2.Text = "创建时间：" + DInfo.CreationTime.ToString();//显示文件夹创建时间
            }
        }
    }
}
