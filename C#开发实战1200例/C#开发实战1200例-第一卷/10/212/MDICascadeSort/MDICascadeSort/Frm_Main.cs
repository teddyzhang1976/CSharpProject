using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDICascadeSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 加载子窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ChildOne frm2 = new Frm_ChildOne();//实例化Frm_ChildOne
            frm2.MdiParent = this;//设置MdiParent属性，将当前窗体作为父窗体
            frm2.Show();//使用Show方法打开窗体
            Frm_ChildTwo frm3 = new Frm_ChildTwo();//实例化Frm_ChildTwo
            frm3.MdiParent = this;//设置MdiParent属性，将当前窗体作为父窗体
            frm3.Show();//使用Show方法打开窗体
            Frm_ChildThree frm4 = new Frm_ChildThree();//实例化Frm_ChildThree
            frm4.MdiParent = this;//设置MdiParent属性，将当前窗体作为父窗体
            frm4.Show();//使用Show方法打开窗体
        }

        private void 层叠排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);//使用MdiLayout枚举实现窗体的层叠排列
        }
    }
}
