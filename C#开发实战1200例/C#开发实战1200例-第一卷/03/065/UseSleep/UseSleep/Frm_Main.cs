using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UseSleep
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(//创建线程对象
                () =>//使用Lambda表达式
                {
                    while (true)//无限循环
                    {
                        Invoke(//在窗体线程中执行
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                txt_Time.Text =//显示系统时间
                                    DateTime.Now.ToString("F");
                            }));
                        Thread.Sleep(1000);//线程挂起1000毫秒
                    }
                });
            th.IsBackground = true;//设置线程为后台线程
            th.Start();//开始执行线程
        }
    }
}
