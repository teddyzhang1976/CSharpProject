using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlProNoTaskBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)//如果选中radioButton1
                this.ShowInTaskbar = true;//将ShowInTaskbar属性设为true，在任务栏显示
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)//如果选中radioButton2
                this.ShowInTaskbar = false;//将ShowInTaskbar属性设为false，不在任务栏显示
        }
    }
}