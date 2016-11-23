using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace MultiKeys
{
    class HOOK
    {
        #region 私有变量

        /// <summary>
        /// 键盘钩子句柄
        /// </summary>
        private IntPtr m_pKeyboardHook = IntPtr.Zero;

        /// <summary>
        /// 钩子委托声明
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        /// <summary>
        /// 键盘钩子委托实例
        /// </summary>
        private HookProc m_KeyboardHookProcedure;

        // 底层键盘钩子
        public const int idHook = 13;

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpfn"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr pInstance, int threadId);

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);

        /// <summary>
        /// 传递钩子
        /// </summary>
        /// <param name="pHookHandle">是您自己的钩子函数的句柄。用该句柄可以遍历钩子链</param>
        /// <param name="nCode">把传入的参数简单传给CallNextHookEx即可</param>
        /// <param name="wParam">把传入的参数简单传给CallNextHookEx即可</param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr pHookHandle, int nCode, Int32 wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyMSG
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        protected const int WM_QUERYENDSESSION = 0x0011;
        protected const int WM_KEYDOWN = 0x100;
        protected const int WM_KEYUP = 0x101;
        protected const int WM_SYSKEYDOWN = 0x104;
        protected const int WM_SYSKEYUP = 0x105;

        public static int pp = 0;//热键的返回值
        public static bool isInstall = false;//是否安装勾子，true为安装
        #endregion

        #region 事件的声明
        public event KeyEventHandler KeyDown;
        #endregion

        #region 方法
        /// <summary>
        /// 钩子捕获消息后，对消息进行处理
        /// </summary>
        /// <param nCode="int">标识，键盘是否操作</param> 
        /// <param wParam="int">键盘的操作值</param>
        /// <param lParam="IntPtr">指针</param>
        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode > -1 && (KeyDown != null))//如果当前的键盘按下操作
            {
                KeyMSG keyboardHookStruct = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));//获取钩子的相关信息
                KeyEventArgs e = new KeyEventArgs((Keys)(keyboardHookStruct.vkCode));//获取KeyEventArgs事件的相关信息
                switch (wParam)
                {
                    case WM_KEYDOWN://键盘的按下操作
                    case WM_SYSKEYDOWN:
                        KeyDown(this, e);//调用KeyDown事件
                        break;
                }
            }
            return pp;
        }

        #endregion

        #region 安装、卸载钩子

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            IntPtr pInstance = (IntPtr)4194304;
            if (this.m_pKeyboardHook == IntPtr.Zero)
            {
                this.m_KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                this.m_pKeyboardHook = SetWindowsHookEx(idHook, m_KeyboardHookProcedure, pInstance, 0);
                if (this.m_pKeyboardHook == IntPtr.Zero)
                {
                    this.Stop();
                    return false;
                }
            }
            isInstall = true;
            return true;
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            if (isInstall == false)
            {
                return true;
            }
            bool result = true;
            if (this.m_pKeyboardHook != IntPtr.Zero)
            {
                result = (UnhookWindowsHookEx(this.m_pKeyboardHook) && result);
                this.m_pKeyboardHook = IntPtr.Zero;
            }
            return result;
        }
        #endregion 公共方法
    }
}
