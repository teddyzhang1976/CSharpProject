using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace UpdateFileAndDirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();							//清空
            folderBrowserDialog1.ShowDialog();				//打开文件夹对话框
            textBox1.Text = folderBrowserDialog1.SelectedPath;	//显示选择的文件夹路径
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);	//实例化DirectoryInfo类
            FileSystemInfo[] f = dir.GetFileSystemInfos();
            //FileInfo[] f = dir.GetFiles();  						//将指定文件夹下的所有文件和文件夹存入到FileInfo[]中
            for (int i = 0; i < f.Length; i++)					//遍历FileInfo[]
            {
                listBox1.Items.Add(f[i]);						//向listBox1控件中添加文件和文件夹的名称
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(listBox1.SelectedItem.ToString()))
                Directory.Move(textBox1.Text + "\\" + listBox1.SelectedItem.ToString(), textBox1.Text + "\\" + textBox2.Text);//移动目录
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Move(textBox1.Text + "\\" + listBox1.SelectedItem.ToString(), textBox1.Text + "\\" + textBox2.Text);//移动文件
        }
    }
}