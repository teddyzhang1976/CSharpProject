using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void cbox_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbox_select.SelectedIndex)//使用switch判断窗体使用哪种颜色
            {
                case 0:
                    this.BackColor = Color.Red;//窗体设置为红色
                    break;
                case 1:
                    this.BackColor = Color.Green;//窗体设置为绿色
                    break;
                case 2:
                    this.BackColor = Color.Blue;//窗体设置为蓝色
                    break;
            }
        }
    }
}
