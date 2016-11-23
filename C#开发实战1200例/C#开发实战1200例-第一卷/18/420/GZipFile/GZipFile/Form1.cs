using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace GZipFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择源文件!", "信息提示");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入压缩文件名!", "信息提示");
                return;
            }

            string str1 = textBox1.Text;
            string str2 = textBox2.Text.Trim() + ".gzip";
            byte[] myByte = null;
            FileStream myStream = null;
            FileStream myDesStream = null;
            GZipStream myComStream = null;
            try
            {
                myStream = new FileStream(str1, FileMode.Open, FileAccess.Read, FileShare.Read);
                myByte = new byte[myStream.Length];
                myStream.Read(myByte, 0, myByte.Length);
                myDesStream = new FileStream(str2, FileMode.OpenOrCreate, FileAccess.Write);
                myComStream = new GZipStream(myDesStream, CompressionMode.Compress, true);
                myComStream.Write(myByte, 0, myByte.Length);
                MessageBox.Show("压缩文件完成！");
            }
            catch { }
            finally
            {
                myStream.Close();
                myComStream.Close();
                myDesStream.Close();
            }
        }
    }
}
