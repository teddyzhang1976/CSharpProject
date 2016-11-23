using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISDirExist
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text);//创建DirectoryInfo对象
                if (dirInfo.Exists)//如果文件夹存在
                {
                    MessageBox.Show("文件夹存在");
                }
                else
                {
                    MessageBox.Show("文件夹不存在");
                }
            }
            catch { }
        }
    }
}
