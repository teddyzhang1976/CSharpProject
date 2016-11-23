using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlyDigit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void txt_Str_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))//判断是否为数字
            {
                MessageBox.Show("请输入数字！","提示！",//弹出消息对话框
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Handled = true;//取消在控件中显示该字符
            }
        }
    }
}
