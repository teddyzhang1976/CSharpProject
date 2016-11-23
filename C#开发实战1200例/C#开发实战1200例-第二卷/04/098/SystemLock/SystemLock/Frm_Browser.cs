using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SystemLock
{
    public partial class Frm_Browser : Form
    {
        public Frm_Browser()
        {
            InitializeComponent();
        }
        public Size s;//获取鼠标活动的区域
        public int x;//获取鼠标活动区域的X坐标
        public int y;//获取鼠标活动区域的Y坐标
        public string infos;//获取挂机信息
        public string pwd;//获取解锁密码
        myHook h = new myHook();//实例化公共类
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(x,y-50);//设置显示挂机信息的位置
            label1.Text = infos;//显示挂机信息
            base.Opacity = 0.5;//设置挂机界面透明度
            h.InsertHook();//安装钩子
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Clip = new Rectangle(x, y, s.Width, s.Height);//设置鼠标活动的区域
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            Frm_UnLock frm3 = new Frm_UnLock();//实例化Form3窗体
            frm3.x = x;//传递X坐标
            frm3.y = y;//传递Y坐标
            frm3.infos = infos;//传递挂机信息
            frm3.pwd = pwd;//传递解锁密码
            frm3.ShowDialog();//打开解锁界面
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();//获取所有系统运行的进程
            foreach (Process p1 in p)//遍历进程
            {
                try
                {
                    //如果进程中存在名为“taskmgr”，则说明任务管理器已经打开   
                    if (p1.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        p1.Kill();//关掉任务管理器的进程
                        Cursor.Clip = new Rectangle(x, y, s.Width, s.Height);//重新设置鼠标活动的区域
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            h.UnInsertHook();//卸载钩子
            timer1.Stop();//停止计时器
        }
    }
}
