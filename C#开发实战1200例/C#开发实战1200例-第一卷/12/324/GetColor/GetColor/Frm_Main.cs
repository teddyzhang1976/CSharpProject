using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Beige;//设置控件背景颜色
          
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;//设置控件背景颜色
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            textBox2.BackColor = Color.White;//设置控件背景颜色
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Beige;//设置控件背景颜色
          
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Beige;//设置控件背景颜色
           

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            textBox4.BackColor = Color.White;//设置控件背景颜色
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.Beige;//设置控件背景颜色
        

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;//设置控件背景颜色
        }

      

      
}
}
