using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace TempFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           textBox1.Text = Path.GetTempFileName();//得到临时文件名称
           FileInfo fin = new FileInfo(textBox1.Text);//创建文件对象
           fin.AppendText();//向文件内追回文本
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();//关闭窗体
        }
    }
}