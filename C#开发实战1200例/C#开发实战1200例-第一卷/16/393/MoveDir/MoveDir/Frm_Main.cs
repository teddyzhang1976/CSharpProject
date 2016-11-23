using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MoveDir
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        FolderBrowserDialog FBDialog = new FolderBrowserDialog();//创建FolderBrowserDialog对象
        private void button1_Click(object sender, EventArgs e)
        {
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择了原文件夹
                textBox1.Text = FBDialog.SelectedPath;//显示原文件夹
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择了目标文件夹
                textBox2.Text = FBDialog.SelectedPath;//显示目标文件夹
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//创建DirectoryInfo对象
                //设置移动路径
                string strPath = textBox2.Text + textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1, textBox1.Text.Length - textBox1.Text.LastIndexOf("\\") - 1);
                DInfo.MoveTo(strPath);//移动文件夹
            }
            catch { MessageBox.Show("移动的文件必须在同一盘符下！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}