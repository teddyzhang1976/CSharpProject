using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DynamicStatus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            int i=1;
            Thread P_th = new Thread(//创建线程对象
                () =>//使用Lambda表达式
                {
                    while (true)//无限循环
                    {
                        Invoke(//调用窗体线程
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                toolStripStatusLabel1.Image =
                                    Image.FromFile((++i > 8 ? (i=1) : i).ToString() + ".bmp");
                            }));
                        Thread.Sleep(50);//线程挂起一秒
                    }
                });
            P_th.IsBackground = true;//设置线程为后台线程
            P_th.Start();//线程开始
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}