using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShieldCtrlV
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)//若按下Ctrl+V组合键
            {
                e.Handled = true;//屏蔽Ctrl+V组合按键
                MessageBox.Show("Ctrl+V组合键已屏蔽","信息提示");
            }
            if (e.Control && e.KeyCode == Keys.X)//若按下Ctrl+X组合键
            {
                e.Handled = true;//屏蔽Ctrl+X组合按键
                MessageBox.Show("Ctrl+X组合键已屏蔽", "信息提示");
            }
            if (e.Control && e.KeyCode == Keys.C)//若按下Ctrl+C组合键
            {
                e.Handled = true;//屏蔽Ctrl+C组合按键
                MessageBox.Show("Ctrl+C组合键已屏蔽", "信息提示");
            }
        }
    }
}
