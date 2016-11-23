using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisableMenuItem
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Enable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到菜单项
                (ToolStripMenuItem)menus_Main.Items[0];
            foreach (ToolStripMenuItem item in 
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Enabled = true;//启用菜单项
            }
        }

        private void btn_Disable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到菜单项
    (ToolStripMenuItem)menus_Main.Items[0];
            foreach (ToolStripMenuItem item in 
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Enabled = false;//停用菜单项
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
                "点击\"打开\"按钮","提示！");
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
                "退出应用程序", "提示！");
            this.Close();//关闭主窗体
        }
    }
}
