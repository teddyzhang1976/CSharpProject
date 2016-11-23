using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IfThenElse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtn_true.Checked)//判断报销是否为业务花销
            {
                MessageBox.Show("正常报销！");//正常报销
            }
            else
            {
                MessageBox.Show("不符合规定报销！");//不符合规定报销
            }
        }
    }
}
