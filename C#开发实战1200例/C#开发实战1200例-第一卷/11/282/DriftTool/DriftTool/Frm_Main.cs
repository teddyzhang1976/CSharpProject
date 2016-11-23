using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DriftTool
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ToolStripPanel tsp_Top = new ToolStripPanel();//创建ToolStripPanel对象
            ToolStripPanel tsp_Bottom = new ToolStripPanel();//创建ToolStripPanel对象
            ToolStripPanel tsp_Left = new ToolStripPanel();//创建ToolStripPanel对象
            ToolStripPanel tsp_right = new ToolStripPanel();//创建ToolStripPanel对象
            tsp_Top.Dock = DockStyle.Top;//设置停靠方式
            tsp_Bottom.Dock = DockStyle.Bottom;//设置停靠方式
            tsp_Left.Dock = DockStyle.Left;//设置停靠方式
            tsp_right.Dock = DockStyle.Right;//设置停靠方式
            Controls.Add(tsp_Top);//添加到控件集合
            Controls.Add(tsp_Bottom);//添加到控件集合
            Controls.Add(tsp_Left);//添加到控件集合
            Controls.Add(tsp_right);//添加到控件集合
            tsp_Bottom.Join(toolStrip1);//将指定的工具栏添加到面板
        }
    }
}
