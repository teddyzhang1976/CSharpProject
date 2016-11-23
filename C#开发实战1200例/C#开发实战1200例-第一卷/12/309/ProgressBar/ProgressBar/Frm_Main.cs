using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }                                      

        private void timer1_Tick(object sender,EventArgs e)
        {
            if(this.progressBar1.Value == this.progressBar1.Maximum)//当进度条的当前值等于最大值时
            {
                this.progressBar1.Value = this.progressBar1.Minimum;//设置进度条的当前值为最小值
            }
            else //当进度条的当前值小于最大值时
            {
                this.progressBar1.PerformStep();//按指定的增量增加进度条中的进度块
            }
            int percentValue = 100 * //将当前进度转化为百分比的形式
                (this.progressBar1.Value - this.progressBar1.Minimum)
                / (this.progressBar1.Maximum - this.progressBar1.Minimum);
            label1.Text = percentValue.ToString() + "%";//在Label中显示百分比的值                                                                                               
        }

        private void StartOrStop_Click(object sender,EventArgs e)
        {
            if(timer1.Enabled)//当Timer处于可用状态时
            {
                timer1.Enabled = false;//设置Timer为不可用状态
                StartOrStop.Text = "开始";//设置“开始”按钮上的文本内容为“开始”
            }
            else//当Timer处于不可用状态时
            {
                timer1.Enabled = true;//设置Timer为可用状态
                StartOrStop.Text = "停止";//设置“停止”按钮上的文本内容为“停止”
            }
        }
    }
}
