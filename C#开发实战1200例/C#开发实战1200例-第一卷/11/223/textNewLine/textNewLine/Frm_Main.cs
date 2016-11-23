using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace textNewLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            txt_Str.Text = string.Format(
                "C#编程词典{0}C#编程宝典{0}C#范例宝典{0}C#视频学",
                Environment.NewLine);
        }
    }
}
