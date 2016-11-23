using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckBoxInStatusBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)//当复选框checkBox2处于选中状态时
            {
                statusStrip1.Items[1].Text = "日期:" + DateTime.Now.ToString();	//在控件statusStrip1中显示系统当前日期
            }
            else							//当复选框checkBox2处于未选中状态时
            {
                statusStrip1.Items[1].Text = "";	//控件statusStrip1的内容设置为空
            }
        }
    }
}