using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MultiKeys
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetCursorPos(Point pnt);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetCursorPos(Point pnt);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 cButtons, Int32 dwExtraInfo);

        const Int32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        const Int32 MOUSEEVENTF_LEFTUP = 0x0004;
        const Int32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const Int32 MOUSEEVENTF_RIGHTUP = 0x0010;
        HOOK Hook = new HOOK();
        public static int tem_Pace = 1;//设置移动速度
        public static Point tem_Point;

        private void Form1_Load(object sender, EventArgs e)
        {
            Hook.KeyDown += new KeyEventHandler(Hook_KeyDown);//加载键盘的按下事件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tem_Pace = Convert.ToInt32(textBox1.Text);//高置鼠标的移动速度
            Hook.Start();//安装钩子
        }

        void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            AddKeyboardEvent(e.KeyValue);
        }

        /// <summary>
        /// 用于屏蔽键盘上指定的键，并通过键值对鼠标进行相应的操作
        /// </summary>
        /// <param value="string">键名称</param>
        public void AddKeyboardEvent(int KeyValue)
        {
            GetCursorPos(tem_Point);//获取鼠标的当前位置
            HOOK.pp = 0;//执行当前键的操作
            switch (KeyValue)
            {
                case 100://向左键
                    {
                        tem_Point.X -= tem_Pace;//鼠标左移
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
                case 104://向上键
                    {
                        tem_Point.Y -= tem_Pace;//鼠标上移
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
                case 102://向右键
                    {
                        tem_Point.X += tem_Pace;
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
                case 98://向下键
                    {
                        tem_Point.Y += tem_Pace;
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
                case 96://单击
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//模拟鼠标的按下事件
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//模拟鼠标的松开事件
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
                case 110://右击
                    {
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);//模拟鼠标右键的按下事件
                        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//模拟鼠标右键的松开事件
                        HOOK.pp = 1;//屏蔽当前键
                        break;
                    }
            }
            SetCursorPos(tem_Point);//设置鼠标的当前位置

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hook.Stop();//卸载钩子
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hook.Stop();//卸载钩子
        }



    }
}
