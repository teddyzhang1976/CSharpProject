using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DisplayRunTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_DateTime;//声明时间字段

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_DateTime = DateTime.Now;//得到系统当前时间
            Thread P_th = new Thread(//创建线程
                () =>//使用Lambda表达式
                {
                    while (true)//无限循环
                    {
                        TimeSpan P_TimeSpan =//得到时间差
                            DateTime.Now - G_DateTime;
                        Invoke(//调用窗体线程
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                tssLabel_Time.Text =//显示程序启动时间
                                    string.Format(
                                    "系统已经运行： {0}天{1}小时{2}分{3}秒",
                                    P_TimeSpan.Days, P_TimeSpan.Hours, 
                                    P_TimeSpan.Minutes, P_TimeSpan.Seconds);
                            }));
                        Thread.Sleep(1000);//线程挂起1秒钟
                    }
                });
            P_th.IsBackground = true;//设置为后台线程
            P_th.Start();//开始执行线程
        }
    }
}
