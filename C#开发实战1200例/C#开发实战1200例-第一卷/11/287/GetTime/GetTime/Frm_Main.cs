using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GetTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Thread P_th = new Thread(//创建线程对象
                () => //使用Lambda表达式
                {
                    while (true)//无限循环
                    {
                        Invoke(//调用窗体线程
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                toolStripStatusLabel1.Text =//设置状态栏文本内容
                                   "当前系统时间： "+ DateTime.Now.ToString("HH时mm分s秒");
                            }));
                        Thread.Sleep(1000);//线程挂起一秒
                    }
                });
            P_th.IsBackground = true;//设置线程为后台线程
            P_th.Start();//线程开始
        }
    }
}