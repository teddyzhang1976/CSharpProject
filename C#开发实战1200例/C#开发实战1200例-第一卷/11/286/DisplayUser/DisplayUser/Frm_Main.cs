using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplayUser
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public string user = string.Empty;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Login P_l = new Login();//创建窗体对象
            P_l.Owner = this;//设置owner属性
            P_l.ShowDialog();//显示窗体
            toolStripStatusLabel1.Text = "登陆用户： "+user;//设置用户登陆信息
        }
    }
}