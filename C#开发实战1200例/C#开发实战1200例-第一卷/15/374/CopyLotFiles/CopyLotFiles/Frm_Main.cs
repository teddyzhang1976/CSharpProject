using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace CopyLotFiles
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            FileInfo[] f = dir.GetFiles();
            for (int i = 0; i < f.Length; i++)
            {
                listBox1.Items.Add(f[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (object o in listBox1.SelectedItems)//遍历所有文件
            {
                File.Copy(textBox1.Text + "\\" + o.ToString(), textBox2.Text + "\\" + o.ToString());//复制文件
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}