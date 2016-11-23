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

namespace UnGzipFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "压缩文件(*.gzip)|*.gzip";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择GZIP文件!", "信息提示");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入解压文件名!", "信息提示");
                return;
            }

            string str1 = textBox1.Text;
            string str2 = textBox2.Text.Trim();
            byte[] myByte = null;
            FileStream myStream = null;
            FileStream myDesStream = null;
            GZipStream myDeComStream = null;
            try
            {
                myStream = new FileStream(str1, FileMode.Open);
                myDeComStream = new GZipStream(myStream, CompressionMode.Decompress, true);
                myByte = new byte[4];
                int myPosition = (int)myStream.Length - 4;
                myStream.Position = myPosition;
                myStream.Read(myByte, 0, 4);
                myStream.Position = 0;
                int myLength = BitConverter.ToInt32(myByte, 0);
                byte[] myData = new byte[myLength + 100];
                int myOffset = 0;
                int myTotal = 0;
                while (true)
                {
                    int myBytesRead = myDeComStream.Read(myData, myOffset, 100);
                    if (myBytesRead == 0)
                        break;
                    myOffset += myBytesRead;
                    myTotal += myBytesRead;
                }
                myDesStream = new FileStream(str2, FileMode.Create);
                myDesStream.Write(myData, 0, myTotal);
                myDesStream.Flush();
                MessageBox.Show("解压文件完成！");
            }
            catch { }
            finally
            {
                myStream.Close();
                myDeComStream.Close();
                myDesStream.Close();
            }
        }
    }
}
