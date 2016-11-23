using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeSysInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            toolTip1.InitialDelay = 1000;//设置在显示之前经过的时间
            toolTip1.ReshowDelay = 500;//设置出现提示窗口出现的时间			
            toolTip1.ShowAlways = true;//设置是否显示提示窗口
            toolTip1.SetToolTip(this.groupBox1, "提示有变化吗？");//设置提示文本与控件关联
        }
    }
}