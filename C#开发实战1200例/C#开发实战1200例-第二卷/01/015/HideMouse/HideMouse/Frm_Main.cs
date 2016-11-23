using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HideMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //重写API函数
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ShowCursor")]
        public extern static bool ShowCursor(bool bShow);

        private void btnHide_Click(object sender, EventArgs e)
        {
            ShowCursor(false);//鼠标隐藏
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowCursor(true);//鼠标显示
        }
    }
}
