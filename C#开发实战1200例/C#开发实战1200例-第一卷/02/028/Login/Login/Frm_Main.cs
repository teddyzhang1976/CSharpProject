using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cbox_select.SelectedItem.//判断用户登陆信息
                ToString() == "admin")
            {
                MessageBox.Show(//如果是admin登陆则提示管理员登陆
                    "管理员登陆","提示！");
            }
            else
            {
                MessageBox.Show(//如果是user登陆则提示普通用户登陆
                    "普通用户登陆", "提示！");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_select.SelectedIndex = 0;//默认选择combobox中的第一项
        }
    }
}
