using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ESCToCloseForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)//判断如果按下的是ESC键
            {
                if (MessageBox.Show("是否要退出程序","信息提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    Application.Exit();//退出应用程序
                }
            }
        }
    }
}