using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmalgamateMenu
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 打开自窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();//创建窗体对象
            f.MdiParent = this;//设置父窗体属性
            f.Show();//显示窗体
            f.Resize += //为窗体添加事件
                new EventHandler(f_Resize);
        }

        void f_Resize(object sender, EventArgs e)
        {
            Form2 f = (Form2)sender;//得到窗体对象
            ToolStripMenuItem item = new ToolStripMenuItem();//创建菜单项
            for (int i = 0; i < f.contextMenuStrip2.Items.Count; )//遍历窗体菜单项集合
            {
                item.DropDownItems.Add(//添加菜单项
                    f.contextMenuStrip2.Items[i]);
            }
            this.contextMenuStrip1.Items.AddRange(//向主窗体中添加菜单项集合
                new System.Windows.Forms.ToolStripItem[] {
            item});
        }
    }
}