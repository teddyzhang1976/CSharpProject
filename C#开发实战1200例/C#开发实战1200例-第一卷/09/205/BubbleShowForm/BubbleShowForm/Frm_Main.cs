using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BubbleShowForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void clewButton_Click(object sender,EventArgs e)
        {
            this.notifyIcon1.Visible = true;//设置提示控件可见
            this.notifyIcon1.ShowBalloonTip(1000,"当前时间：",DateTime.Now.ToLocalTime().ToString(),ToolTipIcon.Info);//显示气泡提示
        }

        private void closeButton_Click(object sender,EventArgs e)
        {
            this.notifyIcon1.Visible = false;//设置提示控件不可见
        }

        private void notifyIcon1_MouseMove(object sender,MouseEventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(1000, "当前时间：", DateTime.Now.ToLocalTime().ToString(), ToolTipIcon.Info);//显示气泡提示
        }
    }
}
