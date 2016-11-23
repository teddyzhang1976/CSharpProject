using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExecEXEFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "exe文件(*.exe)|*.exe";//设置打开文件的格式
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了exe而文件
                textBox1.Text = openFileDialog1.FileName;//显示选择的文件
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);//执行exe文件
        }
    }
}