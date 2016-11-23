using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulButton
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void transparencyButton1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
                "已经点击了按钮控件","提示！");
        }
    }
}
