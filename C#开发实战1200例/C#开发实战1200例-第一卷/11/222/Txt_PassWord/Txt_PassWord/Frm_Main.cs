using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Txt_PassWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Str_Click(object sender, EventArgs e)
        {
            txt_Change.PasswordChar = (char)0;//取消屏蔽
        }

        private void btn_PassWord_Click(object sender, EventArgs e)
        {
            txt_Change.PasswordChar = '*';//设置屏蔽字符
        }
    }
}
