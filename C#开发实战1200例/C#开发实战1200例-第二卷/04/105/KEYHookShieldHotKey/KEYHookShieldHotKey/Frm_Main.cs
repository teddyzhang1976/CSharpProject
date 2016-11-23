using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KEYHookShieldHotKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private IntPtr pKeyboardHook = IntPtr.Zero;//键盘钩子句柄
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);// 钩子委托声明
        //键盘钩子委托实例不能省略变量
        private HookProc KeyboardHookProcedure;
        //底层键盘钩子
        public const int idHook = 13;
        //安装钩子
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn,
            IntPtr pInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);
        //键盘钩子处理函数
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            KeyMSG m = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));
            if (pKeyboardHook != IntPtr.Zero)
            {
                switch (((Keys)m.vkCode))
                {
                    case Keys.LWin:
                    case Keys.RWin:
                    case Keys.Delete:
                    case Keys.Alt:
                    case Keys.Escape:
                    case Keys.F4:
                    case Keys.Control:
                    case Keys.Tab:
                        return 1;
                }
            }
            return 0;
        }
        //安装钩子
        public bool InsertHook()
        {
            IntPtr pIn = (IntPtr)4194304;
            if (this.pKeyboardHook == IntPtr.Zero)//如果没安装钩子
            {
                this.KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                //安装钩子
                this.pKeyboardHook = SetWindowsHookEx(idHook, KeyboardHookProcedure, pIn, 0);
                if (this.pKeyboardHook == IntPtr.Zero)//如果安装钩子失败
                {
                    this.UnInsertHook();//卸载钩子
                    return false;//返回false
                }
            }
            return true;
        }
        //卸载钩子
        public bool UnInsertHook()
        {
            bool result = true;
            if (this.pKeyboardHook != IntPtr.Zero)//如果存在键盘钩子
            {
                result = (UnhookWindowsHookEx(this.pKeyboardHook) && result);//卸载钩子
                this.pKeyboardHook = IntPtr.Zero;
            }
            return result;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyMSG
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                InsertHook();
            }
            else
            {
                UnInsertHook();
            }
        }
    }
}
