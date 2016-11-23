using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            System.Threading.Thread P_thread = //创建线程
                new System.Threading.Thread(
                () =>//使用lambda表达式
                {
                    while (true)//无限循环
                    {
                        this.Invoke(//操作窗体线程
                              (MethodInvoker)delegate()//使用匿名方法
                                     {
                                         this.Refresh();//刷新窗体
                                         Graphics P_Graphics = //创建绘图对象
                                             CreateGraphics();
                                         P_Graphics.DrawString("系统时间：" +//在窗体中绘出系统时间
                                             DateTime.Now.ToString(
                                             "yyyy年MM月dd日 HH时mm分ss秒"),
                                             new Font("宋体", 15),
                                             Brushes.Blue,
                                             new Point(10, 10));
                                     });
                        System.Threading.Thread.Sleep(1000);//线程挂起1秒钟
                    }
                });
            P_thread.IsBackground = true;//将线程设置为后台线程
            P_thread.Start();//线程开始执行
        }
    }
}
