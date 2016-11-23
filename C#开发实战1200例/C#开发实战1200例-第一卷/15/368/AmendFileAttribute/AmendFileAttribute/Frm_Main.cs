using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace AmendFileAttribute
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo f = new System.IO.FileInfo(textBox1.Text);			//实例化FileInfo类
            if (checkBox1.Checked == true)									//如果只读复选框选中
            {
                f.Attributes = System.IO.FileAttributes.ReadOnly; 				//设置文件为只读
            }
            if (checkBox2.Checked == true) 								//如果系统复选框选中
            {
                f.Attributes = System.IO.FileAttributes.System; 					//设置文件为系统
            }
            if (checkBox3.Checked == true) 								//如果存档复选框选中
            {
                f.Attributes = System.IO.FileAttributes.Archive; 					//设置文件为存档
            }
            if (checkBox4.Checked == true) 								//如果隐藏复选框选中
            {
                f.Attributes = System.IO.FileAttributes.Hidden; 					//设置文件为隐藏
            }
        }
    }
}