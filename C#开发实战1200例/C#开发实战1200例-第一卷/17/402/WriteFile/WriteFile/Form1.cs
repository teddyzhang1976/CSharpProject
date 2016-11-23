using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WriteFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请设置文件！");
                return;
            }
            try
            {
                FileStream FStream = File.OpenWrite(textBox1.Text);
                Byte[] info = Encoding.Default.GetBytes(textBox2.Text);
                FStream.Write(info, 0, info.Length);
                FStream.Close();
                MessageBox.Show("写入文件成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
