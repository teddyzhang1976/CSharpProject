using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageNavigationForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = true;//设置button5控件可见
            button6.Visible = true;//设置button6控件可见
            button7.Visible = true;//设置button7控件可见
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button8.Visible = true;//设置button8控件可见
            button9.Visible = true;//设置button9控件可见
            button10.Visible = true;//设置button10控件可见
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button11.Visible = true;//设置button1控件可见
            button12.Visible = true;//设置button2控件可见
            button13.Visible = true;//设置button3控件可见
        }
    }
}