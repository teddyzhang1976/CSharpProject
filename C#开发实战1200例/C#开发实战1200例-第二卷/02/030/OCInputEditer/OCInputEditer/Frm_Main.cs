using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace OCInputEditer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.ImeMode = ImeMode.Off;//关闭输入法
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.ImeMode = ImeMode.On;//打开输入法
        }
    }
}