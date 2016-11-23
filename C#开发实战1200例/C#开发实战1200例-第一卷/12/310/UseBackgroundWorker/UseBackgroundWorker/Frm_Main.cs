using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace UseBackgroundWorker
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private int numberToCompute = 0;
        private int highestPercentageReached = 0;

        //在另一个线程上运行事件处理和序
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ComputeFibonacci((int)e.Argument, this.backgroundWorker1, e);
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)//是否有错误信息
            {
                MessageBox.Show(//弹出消息对话框
                    e.Error.Message);
            }
            else if (e.Cancelled)//异步操作是否被取消
            {
                resultLabel.Text = "Canceled";//返回字符串对象
            }
            else
            {
                resultLabel.Text = e.Result.ToString();//显示结果
            }
            numericUpDown1.Enabled = true;//启用numericUpDown控件
            startAsyncButton.Enabled = true;//启用开始按钮
            cancelAsyncButton.Enabled = false;//停用取消按钮
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
           
            resultLabel.Text = String.Empty;//得到空字符串对象
            this.numericUpDown1.Enabled = false;//停用numericUpDown控件
            this.startAsyncButton.Enabled = false;//停用开始按钮
            this.cancelAsyncButton.Enabled = true;//启用取消按钮
            numberToCompute = (int)numericUpDown1.Value;//得到numericUpDown控件的值
            highestPercentageReached = 0;//设置值为0
            backgroundWorker1.RunWorkerAsync(numberToCompute);//开始执行后台操作
        }

        long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentException(//抛出异常
                    "value must be >= 0 and <= 91", "n");
            }
            long result = 0;//声明长整型变量并赋值
            if (worker.CancellationPending)//判断是否已经取消后台操作
            {
                e.Cancel = true;//设置取消事件
            }
            else
            {
                if (n < 2)
                {
                    result = 1;//方法返回1
                }
                else
                {
                    result = ComputeFibonacci(n - 1, worker, e) +//使用递归得到结果
                             ComputeFibonacci(n - 2, worker, e);
                }

                int percentComplete =
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;//返回结果
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();//取消挂起的后台操作
            cancelAsyncButton.Enabled = false;//停用取消按钮

        }
    }
}