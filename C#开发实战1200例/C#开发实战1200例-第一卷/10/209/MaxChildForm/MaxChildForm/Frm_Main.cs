using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MaxChildForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Child frm = new Frm_Child();//实例化子窗体对象
            frm.MdiParent = this;//设置子窗体的父窗体为当前窗体
            frm.WindowState = FormWindowState.Maximized;//设置子窗体最大化显示
            frm.Show();//显示子窗体
        }
    }
}