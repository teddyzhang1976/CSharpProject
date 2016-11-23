using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetGroupKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control == true) && (e.KeyCode == Keys.A))//判断是否按下了Ctrl+A组合键
            {
                MessageBox.Show("您按下组合键Ctrl+A");
            }
        }
    }
}