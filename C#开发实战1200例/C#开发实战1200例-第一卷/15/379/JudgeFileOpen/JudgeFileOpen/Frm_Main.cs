using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace JudgeFileOpen
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;							//没有被选中
            checkBox2.Checked = true;							//被选中
            openFileDialog1.ShowDialog();						//打开文件对话框
            try
            {
                System.IO.File.Move(openFileDialog1.FileName, openFileDialog1.FileName);		//移动文件
            }
            catch								//如果移动文件产生异常则说明文件被打开
            {
                checkBox2.Checked = false;					//没有被选中
                checkBox1.Checked = true; 					//被选中
            }
        }
    }
}