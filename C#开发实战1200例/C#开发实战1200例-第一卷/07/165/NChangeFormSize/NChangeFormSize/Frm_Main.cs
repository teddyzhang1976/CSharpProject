using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NChangeFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;//禁用最大化按钮
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//设置窗体边框样式为对话框样式
        }
    }
}