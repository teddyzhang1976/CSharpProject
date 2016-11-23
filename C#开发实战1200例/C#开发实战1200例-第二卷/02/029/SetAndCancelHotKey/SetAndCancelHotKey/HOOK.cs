using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace SetAndCancelHotKey
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

        /// <summary>
        /// 底层的钩子变量
        /// </summary>
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

        protected const byte VK_SHIFT = 0x10;
        protected const byte VK_CAPITAL = 0x14;
        protected const byte VK_NUMLOCK = 0x90;

        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        protected const int VK_LWIN = 91;
        protected const int VK_RWIN = 92;
        protected const byte VK_LCONTROL = 0xA2;
        protected const byte VK_RCONTROL = 0x3;
        protected const byte VK_LALT = 0xA4;
        protected const byte VK_RALT = 0xA5;

        protected const byte LLKHF_ALTDOWN = 0x20;
        public bool Porwer = true;//是否屏蔽Porwer键
        public static int pp = 0;//热键的返回值
        public static bool isSet = false;//是否设置屏蔽热键,false为设置屏蔽的热键
        public static bool isHotkey = false;
        public static bool isInstall = false;//是否安装钩子，true为安装
        #endregion

        #region 事件的声明
        public event KeyEventHandler KeyDown;//键盘按下事件
        public event KeyEventHandler KeyUp;//键盘松开事件
        public event KeyPressEventHandler KeyPress;//键盘单击事件
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
            if (nCode > -1 && (KeyDown != null || KeyUp != null || KeyPress != null))
            {

                KeyMSG keyboardHookStruct = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));//获取钩子的相关信息
                KeyEventArgs e = new KeyEventArgs((Keys)(keyboardHookStruct.vkCode));//获取KeyEventArgs事件的相磁信息
                switch (wParam)
                {
                    case WM_KEYDOWN://键盘按下操作
                    case WM_SYSKEYDOWN:
                        if (KeyDown != null)//如果加载了当前事件
                        {
                            KeyDown(this, e);//调用该事件
                        }
                        break;
                    case WM_KEYUP://键盘松开操作
                    case WM_SYSKEYUP:
                        if (KeyUp != null)//如果加载了当前事件
                        {
                            KeyUp(this, e);//调用该事件
                        }
                        break;
                }
            }
            return pp;//是否屏蔽当前热键，1为屏蔽，2为执行
        }
        #endregion

        #region 安装、卸载钩子

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <returns>是否安装成功</returns>
        public bool Start()
        {
            IntPtr pInstance = (IntPtr)4194304;//钩子所在实例的句柄
            if (this.m_pKeyboardHook == IntPtr.Zero)//如果键盘的句柄为空
            {
                this.m_KeyboardHookProcedure = new HookProc(KeyboardHookProc);//声明一个托管钩子
                this.m_pKeyboardHook = SetWindowsHookEx(idHook, m_KeyboardHookProcedure, pInstance, 0);//安装钩子
                if (this.m_pKeyboardHook == IntPtr.Zero)//如果安装失败
                {
                    this.Stop();//卸载钩子
                    return false;
                }
            }
            isInstall = true;//安装了钩子
            return true;
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <returns>是否卸载成功</returns>
        public bool Stop()
        {
            if (isInstall == false)//如果没有安装钩子
            {
                return true;
            }
            bool result = true;
            if (this.m_pKeyboardHook != IntPtr.Zero)//如果安装了钩子
            {
                result = (UnhookWindowsHookEx(this.m_pKeyboardHook) && result);//卸载钩子
                this.m_pKeyboardHook = IntPtr.Zero;//清空键盘的钩子句柄
            }
            return result;
        }
        #endregion 公共方法
    }
}
