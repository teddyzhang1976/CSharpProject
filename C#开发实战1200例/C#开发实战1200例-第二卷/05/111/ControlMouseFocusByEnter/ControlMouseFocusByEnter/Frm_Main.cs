using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlMouseFocusByEnter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)//如果按下回车键
                txtPWD.Focus();//切换鼠标焦点
        }

        private void txtPWD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)//如果按下回车键
                btnOK.Focus();//切换鼠标焦点
        }
    }
}