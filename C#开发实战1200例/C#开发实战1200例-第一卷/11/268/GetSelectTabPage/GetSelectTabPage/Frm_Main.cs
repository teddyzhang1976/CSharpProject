using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetSelectTabPage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.Normal;//设置选项卡的外观样式
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string P_str_TabName = tabControl1.SelectedTab.Text;//获取选择的选项卡名称
            MessageBox.Show("您选择的选项卡为：" + P_str_TabName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出信息提示
        }
    }
}
