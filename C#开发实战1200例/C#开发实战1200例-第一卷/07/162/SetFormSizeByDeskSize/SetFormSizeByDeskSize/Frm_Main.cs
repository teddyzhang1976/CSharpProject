using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SetFormSizeByDeskSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;//获取桌面宽度
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;//获取桌面高度
            this.Width = Convert.ToInt32(DeskWidth * 0.8);//设置窗体宽度
            this.Height = Convert.ToInt32(DeskHeight * 0.8);//设置窗体高度
        }
    }
}