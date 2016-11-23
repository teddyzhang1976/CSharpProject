using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShieldMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Shield_Click(object sender, EventArgs e)
        {
            txt_Str.ShortcutsEnabled = false;//停用文本框的快捷方式
        }
    }
}
