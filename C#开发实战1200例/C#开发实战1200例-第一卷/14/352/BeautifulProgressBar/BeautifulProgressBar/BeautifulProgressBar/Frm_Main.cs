using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsControlLibrary;

namespace BeautifulProgressBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender,EventArgs e)
        {
            if(this.BeautifulProgressBar1.Value > 0) //当BeautifulProgressBar1控件的当前值大于0时
            {
                this.BeautifulProgressBar1.Value--;//设置BeautifulProgressBar1控件的当前值递减
                this.BeautifulProgressBar2.Value++;//设置BeautifulProgressBar2控件的当前值递增
            }
            else//当BeautifulProgressBar1控件的当前值小于0时
            {
                this.timer1.Enabled = false;//使Timer组件处于不可用状态
            }
        }

        private void StartOrStop_Click(object sender,EventArgs e)
        {
            this.BeautifulProgressBar1.Value = 100;//设置BeautifulProgressBar1的值为100
            this.BeautifulProgressBar2.Value = 0;//设置BeautifulProgressBar2的值为0

            this.timer1.Interval = 1;//设置Timer组件的Tick事件的时间间隔
            this.timer1.Enabled = true;//设置Timer组件为可用状态
        }
    }
}
