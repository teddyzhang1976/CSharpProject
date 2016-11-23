using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoveForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Screen.GetWorkingArea(this);//获取屏幕大小
            if (this.Left != (rect.Width - this.Width))
            {
                this.Left++;//窗体向右移动
                this.Top += 1;//窗体向下移动
            }
            else
            {
                timer1.Enabled = false;//停用Timer组件
                timer2.Enabled = true;//启用Timer组件
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Screen.GetWorkingArea(this);//获取屏幕大小
            if (this.Left == 0)
            { 
                timer2.Enabled = false;//停用Timer组件
                timer1.Enabled = true;//启用Timer组件
            }
            else
            {
                this.Left--;//窗体向左移动
                this.Top -= 1;//窗体向上移动
            }
        }
    }
}