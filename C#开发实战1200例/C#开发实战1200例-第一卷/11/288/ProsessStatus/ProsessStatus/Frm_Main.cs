using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProsessStatus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
            {
                this.toolStripProgressBar1.PerformStep();//增加进度条进度
            }
        }
    }
}