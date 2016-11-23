using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DefaultSelectFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = @"D:\";//设置选定的路径
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//确定是否已经选择文件夹
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;//显示文件夹路径
            }
        }
    }
}