using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ButtonShortCut
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
              "点击了确定！", "提示！");
        }
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
             "点击了退出！", "提示！");
        }
    }
}
