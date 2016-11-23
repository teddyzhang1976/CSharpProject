using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OpenMulti
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt文件(*.txt)|*.txt";//筛选文件
            openFileDialog1.Multiselect = true;//允许选中多个文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选中文件
            {
                string Content = string.Empty;
                foreach (string filename in openFileDialog1.FileNames)
                {
                    System.IO.StreamReader sr = new//创建流读取器对象
                         System.IO.StreamReader(filename,Encoding.Default);
                    Content += sr.ReadToEnd();//读取文件内容
                    sr.Close();//关闭流
                }
                textBox1.Text = Content;//显示文件内容
            }
        }
    }
}