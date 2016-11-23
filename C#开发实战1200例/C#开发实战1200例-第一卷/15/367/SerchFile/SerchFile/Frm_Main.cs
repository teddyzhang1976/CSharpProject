using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SerchFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请输入要查找的文件");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("请输入要查找的目录");
                return;
            }

            listView1.Items.Clear();
            SearchFile(textBox2.Text);
            MessageBox.Show("搜索完毕");
        }
        //自定义方法，用于在指定的文件夹下搜索文件
        public void SearchFile(string fileDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(fileDirectory);			//实例化DirectoryInfo类
            FileSystemInfo[] f = dir.GetFileSystemInfos();					//获取文件夹下文件
            foreach (FileSystemInfo i in f)								//对指定的文件夹进行遍历
            {
                if (i is DirectoryInfo)								//如果是文件夹
                {
                    SearchFile(i.FullName);							//递归调用
                }
                else
                {
                    if (i.Name == textBox1.Text)						//如果等于指定的文件名
                    {
                        FileInfo fin = new FileInfo(i.FullName);			//实例化FileInfo类
                        listView1.Items.Add(fin.Name);					//为ListView添加文件的名称
                        //为ListView添加文件的路径
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.FullName);
                        //为ListView添加文件大小
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.Length.ToString());
                        //为ListView添加文件的创建时间
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fin.CreationTime.ToString());
                    }
                }
            }
        }
    }
}