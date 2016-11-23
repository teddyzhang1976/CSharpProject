using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseTimer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int index = 0;

        private void tmr_Action_Tick(object sender, EventArgs e)
        {
            CreateGraphics().DrawImage(//在窗体中绘制图片信息
                Image.FromFile(
                (index++ > 7 ? (index = 1) : index).
                ToString() + ".jpg"), new Point(0, 0));
        }
    }
}
