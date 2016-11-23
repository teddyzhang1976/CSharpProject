using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShortCutInMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出应用程序","提示！");
            Close();//退出应用程序
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已经点击\"打开\"菜单项", "提示！");
        }
    }
}
