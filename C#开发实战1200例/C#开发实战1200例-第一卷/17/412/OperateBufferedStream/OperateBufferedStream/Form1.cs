using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OperateBufferedStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文件(*.*)|*.*";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = textBox1.Text;
                string str2 = textBox2.Text + "\\" + textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1, textBox1.Text.Length - textBox1.Text.LastIndexOf("\\") - 1);
                Stream myStream1, myStream2;
                BufferedStream myBStream1, myBStream2;
                byte[] myByte = new byte[1024];
                int i;
                myStream1 = File.OpenRead(str1);
                myStream2 = File.OpenWrite(str2);
                myBStream1 = new BufferedStream(myStream1);
                myBStream2 = new BufferedStream(myStream2);
                i = myBStream1.Read(myByte, 0, 1024);
                while (i > 0)
                {
                    myBStream2.Write(myByte, 0, i);
                    i = myBStream1.Read(myByte, 0, 1024);
                }
                myBStream2.Flush();
                myStream1.Close();
                myBStream2.Close();
                MessageBox.Show("文件复制完成");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
