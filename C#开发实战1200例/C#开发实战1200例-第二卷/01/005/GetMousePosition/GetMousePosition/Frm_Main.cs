using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetMousePosition
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.labX.Text = e.X.ToString();//显示X坐标
            this.labY.Text = e.Y.ToString();//显示Y坐标
        }
    }
}