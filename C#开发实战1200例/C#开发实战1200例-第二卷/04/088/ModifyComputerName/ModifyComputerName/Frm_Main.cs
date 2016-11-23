using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;

namespace ModifyComputerName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        private static extern int SetComputerName(string ipComputerName);//重写API函数

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Computer computer = new Computer();//创建计算机对象
            textBox1.Text = computer.Name;//显示计算机名称
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")//判断计算机名称是否为空
            {
                MessageBox.Show("计算机名称不能为空！");
            }
            else
            {
                SetComputerName(textBox2.Text);//修改计算机名称
                MessageBox.Show("计算机名称修改成功，请重新启动计算机使之生效！");
            }
        }
    }
}
