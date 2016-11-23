using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BackupAndRestoreAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();//创建打开对话框对象
            OpenFile.Filter = "*.mdb(Access数据库文件)|*.mdb";//设置只能打开Access文件
            if (OpenFile.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                textBox1.Text = OpenFile.FileName;//显示选择的文件
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();//创建浏览文件夹对话框对象
            if (FolderBrowser.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                if (FolderBrowser.SelectedPath.EndsWith("\\"))//判断文件夹是否以\结尾
                    textBox2.Text = FolderBrowser.SelectedPath;//显示选择的文件夹
                else
                    textBox2.Text = FolderBrowser.SelectedPath + "\\";//将选择的文件夹加\之后显示
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string P_str_Path = textBox2.Text + textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1);//记录备份文件路径
            if (!File.Exists(P_str_Path))//判断备份文件是否存在
            {
                File.Copy(textBox1.Text, P_str_Path);//备份文件
                MessageBox.Show("数据备份成功！");
            }
            else
            {
                MessageBox.Show("备份文件已经存在，请重新选择路径！");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();//创建打开对话框对象
            OpenFile.Filter = "*.mdb(Access数据库文件)|*.mdb";//设置只能打开Access文件
            if (OpenFile.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                textBox4.Text = OpenFile.FileName;//显示选择的文件
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();//创建浏览文件夹对话框对象
            if (FolderBrowser.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                if (FolderBrowser.SelectedPath.EndsWith("\\"))//判断文件夹是否以\结尾
                    textBox3.Text = FolderBrowser.SelectedPath;//显示选择的文件夹
                else
                    textBox3.Text = FolderBrowser.SelectedPath + "\\";//将选择的文件夹加\之后显示
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string P_str_Path = textBox3.Text + textBox4.Text.Substring(textBox4.Text.LastIndexOf("\\") + 1);//记录还原文件路径
            File.Copy(textBox4.Text, P_str_Path, true);//还原文件
            MessageBox.Show("数据还原成功！");
        }
    }
}
