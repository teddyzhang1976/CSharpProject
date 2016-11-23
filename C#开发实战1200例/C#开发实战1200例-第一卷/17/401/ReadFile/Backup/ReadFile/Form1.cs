using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "文本文件(*.txt)|*.txt";//设置打开文件的类型
                openFileDialog1.ShowDialog();
                textBox1.Text = openFileDialog1.FileName;//设置打开的文件名称
                FileStream fs = File.OpenRead(textBox1.Text);//打开现有文件以进行读取
                byte[] b = new byte[1024];//定义缓存
                while (fs.Read(b, 0, b.Length) > 0)//循环每次读取1024个字节到缓存中
                {
                    textBox2.Text = Encoding.Default.GetString(b);//把字节数组所有字节转为一个字符串
                }
            }
            catch { MessageBox.Show("请选择文件"); }
        }
    }
}
