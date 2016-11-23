using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoldItem
{
    public partial class Main_Main : Form
    {
        public Main_Main()
        {
            InitializeComponent();
        }

        private void btn_Bold_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem P_ToolStripMenuItem =//得到菜单项
                (ToolStripMenuItem)menus_Bold.Items[0];
            foreach (ToolStripItem item in //遍历菜单项集合
                P_ToolStripMenuItem.DropDownItems)
            {
                item.Font = //设置菜单项字体
                    new Font(new Font("宋体",9), FontStyle.Bold);
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对框
                "点击\"打开\"项","提示！");
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对框
                "退出应用程序","提示！");
            this.Close();//关闭主窗体
        }

    }
}
