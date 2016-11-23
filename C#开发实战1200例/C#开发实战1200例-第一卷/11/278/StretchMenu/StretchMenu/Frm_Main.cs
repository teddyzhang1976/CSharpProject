using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StretchMenu
{
    public partial class Frm_Main : Form
    {
        bool G_bl = true;//设置布尔字段用于展开缩进菜单项
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.设置密码ToolStripMenuItem.Visible = false;//隐藏菜单项
            this.添加用户ToolStripMenuItem.Visible = false;//隐藏菜单项
            this.忘记密码ToolStripMenuItem.Visible = false;//隐藏菜单项
            this.修改密码ToolStripMenuItem.Visible = false;//隐藏菜单项
            this.员工录入ToolStripMenuItem.Visible = false;//隐藏菜单项
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (G_bl)
            {
                case false:
                    this.设置密码ToolStripMenuItem.Visible = false;//隐藏菜单项
                    this.添加用户ToolStripMenuItem.Visible = false;//隐藏菜单项
                    this.忘记密码ToolStripMenuItem.Visible = false;//隐藏菜单项
                    this.修改密码ToolStripMenuItem.Visible = false;//隐藏菜单项
                    this.员工录入ToolStripMenuItem.Visible = false;//隐藏菜单项
                    G_bl = true;//设置布尔值
                    操作ToolStripMenuItem.ShowDropDown();//显示菜单项
                    break;
                case true:
                    this.设置密码ToolStripMenuItem.Visible = true;//显示菜单项
                    this.添加用户ToolStripMenuItem.Visible = true;//显示菜单项
                    this.忘记密码ToolStripMenuItem.Visible = true;//显示菜单项
                    this.修改密码ToolStripMenuItem.Visible = true;//显示菜单项
                    this.员工录入ToolStripMenuItem.Visible = true;//显示菜单项
                    G_bl = false;//设置布尔值
                    this.操作ToolStripMenuItem.ShowDropDown();//显示菜单项
                    break;
            }
        }
    }
}