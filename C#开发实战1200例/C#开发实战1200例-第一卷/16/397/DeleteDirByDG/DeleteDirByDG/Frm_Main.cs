using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeleteDirByDG
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
                textBox1.Text = FBDialog.SelectedPath;//显示选择的文件夹
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//创建DirectoryInfo对象
            FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();//获取所有文件
            for (int i = 0; i < FSInfo.Length; i++)//遍历获取到的文件
            {
                FileInfo FInfo = new FileInfo(textBox1.Text + "\\" + FSInfo[i].ToString());//创建FileInfo对象
                FInfo.Delete();//删除文件
            }
            MessageBox.Show("删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}