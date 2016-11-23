using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NullificationMouse
{
    class MouseHook
    {
        #region 声明的变量
        public const int WH_MOUSE_LL = 14;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_MBUTTONUP = 0x208;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_MBUTTONDBLCLK = 0x209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public IntPtr mouseHandler = IntPtr.Zero;
        public event MouseEventHandler MouseDown;
        //该变量标识屏蔽项
        public static int flag = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //声明一个钩子函数
        public static extern int SetWindowsHookEx(int HookType, HOOKPROCEDURE methodAddress, IntPtr handler, int dwThreadId);

        //释放钩子函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        //声明钩子函数地址
        public delegate int HOOKPROCEDURE(int nCode, Int32 wParam, IntPtr IParam);

        private HOOKPROCEDURE m_MouseHookProcedure;

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected class POINT
        {
            public int x;
            public int y;
        }

        #endregion

        #region 安装钩子
        public bool StartHook()
        {
            IntPtr InstallHook = (IntPtr)(4194304);
            if (this.mouseHandler == IntPtr.Zero)
            {
                this.m_MouseHookProcedure = new HOOKPROCEDURE(MouseHookProcedure);
                this.mouseHandler = (IntPtr)SetWindowsHookEx(WH_MOUSE_LL, m_MouseHookProcedure, InstallHook, 0);
                if (this.mouseHandler == IntPtr.Zero)
                {
                    //释放钩子
                    this.UnInstallHook();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 鼠标钩子处理函数
        private int MouseHookProcedure(int nCode, Int32 wParam, IntPtr IParam)
        {
            if (nCode >= 0 && MouseDown != null)
            {
                MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(IParam, typeof(MouseHookStruct));
                MouseButtons button = GetButton(wParam);
                short mouseDelta = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                    case WM_LBUTTONDBLCLK:
                    case WM_LBUTTONUP: button = MouseButtons.Left;
                        if (Frm_Main.flagL == true)
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                        break;
                    case WM_RBUTTONDOWN:
                    case WM_RBUTTONDBLCLK:
                    case WM_RBUTTONUP: button = MouseButtons.Right;
                        if (Frm_Main.flagR == true)
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                        break;
                    case WM_MOUSEWHEEL: mouseDelta = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);
                        if (Frm_Main.flagM == true)
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                        break;
                    case WM_MOUSEMOVE: flag = 0;
                        break;
                }
                int clickCount = 0;
                if (wParam == WM_LBUTTONDBLCLK || wParam == WM_RBUTTONDBLCLK)
                {
                    clickCount = 2;
                }
                else
                {
                    clickCount = 1;
                }
                System.Windows.Forms.MouseEventArgs e = new System.Windows.Forms.MouseEventArgs(button, clickCount, mouseHookStruct.pt.x, mouseHookStruct.pt.y, mouseDelta);
                MouseDown(this, e);
            }
            return flag;

        }
        #endregion

        #region 释放钩子函数
        public bool UnInstallHook()
        {
            bool Result = true;
            if (this.mouseHandler != IntPtr.Zero)
            {
                Result = (UnhookWindowsHookEx(this.mouseHandler) && Result);
                this.mouseHandler = IntPtr.Zero;
            }
            return Result;
        }
        #endregion

        #region 获取鼠标按键类型
        private MouseButtons GetButton(Int32 wParam)
        {
            switch (wParam)
            {
                case WM_LBUTTONDBLCLK:
                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                    return MouseButtons.Left;
                case WM_RBUTTONDBLCLK:
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                    return MouseButtons.Right;
                case WM_MBUTTONDBLCLK:
                case WM_MBUTTONDOWN:
                case WM_MBUTTONUP:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;
            }
        }
        #endregion
    }
}
