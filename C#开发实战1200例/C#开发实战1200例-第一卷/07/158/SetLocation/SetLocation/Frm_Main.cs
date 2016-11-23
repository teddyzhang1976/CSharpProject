using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetLocation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Left = Convert.ToInt32(textBox1.Text);//设置窗体左边缘与屏幕左边缘之间的距离
            this.Top = Convert.ToInt32(textBox2.Text);//设置窗体上边缘与屏幕上边缘之间的距离
        }
    }
}