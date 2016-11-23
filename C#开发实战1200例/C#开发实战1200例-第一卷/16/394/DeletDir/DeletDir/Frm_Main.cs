using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeletDir
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
            DInfo.Delete(true);//删除文件夹所有内容
            MessageBox.Show("删除文件夹成功！");
        }
    }
}