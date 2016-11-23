using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileIsExists
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))//判断文件是否存在
                MessageBox.Show("该文件已经存在");
            else
                MessageBox.Show("该文件不存在");
        }

    }
}
