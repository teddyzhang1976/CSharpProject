using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;

namespace RMachine
{
    public partial class Frm_Machine : Form
    {
        public Frm_Machine()
        {
            InitializeComponent();
        }

        SoftReg softreg = new SoftReg();//实例化公共类对象
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("机器码输入不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBox2.Text = softreg.getRNum();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
