using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShowDialogByClose
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)//触发窗体关闭事件
        {
            if (MessageBox.Show("将要关闭窗体，是否继续？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)//判断是否单击了“是”按钮
            {
                e.Cancel = false;//关闭窗体
            }
            else
            {
                e.Cancel = true;//取消事件的执行
            }
        }
    }
}