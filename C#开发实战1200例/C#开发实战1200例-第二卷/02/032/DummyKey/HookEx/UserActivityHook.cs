using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace HookEx
{
    //键盘事件KeyDown、KeyUp
    public class KeyExEventArgs : KeyEventArgs
    {
        private int flags;
        //获取键的代码值
        public KeyExEventArgs(Keys keyData, int flags) : base(keyData)
        {
            this.flags = flags;
        }
        public int Flags;
    }

    //鼠标事件
    public class MouseExEventArgs : MouseEventArgs
    {
        private int flags;
        public MouseExEventArgs(MouseButtons button, int clicks, int x, int y, int delta, int flags) : base(button, clicks, x, y, delta)
        {
            this.flags = flags;
        }
        public int Flags;
    }

    //键盘事件KeyPress
    public class KeyPressExEventArgs : KeyPressEventArgs
    {
        private int flags;
        public KeyPressExEventArgs(char keyChar, int flags) : base(keyChar)
        {
            this.flags = flags;
        }
        public int Flags;
    }

    public sealed class UserActivityHook
    {
        private IntPtr hMouseHook = IntPtr.Zero;//设置句柄为空
        private IntPtr hKeyboardHook = IntPtr.Zero;
        private static readonly EventKey EventMouseActivity = new EventKey();//声明鼠标事件
        private static readonly EventKey EventKeyDown = new EventKey();//声明键盘按下事件
        private static readonly EventKey EventKeyPress = new EventKey();//声明键盘的KeyPass事件
        private static readonly EventKey EventKeyUp = new EventKey();//声明键盘松开事件
        private static HookProc MouseHookProcedure;
        private static HookProc KeyboardHookProcedure;
        private readonly EventSet Events = new EventSet();//实例化自定义EventSet类

        #region 设置构造函数
        [StructLayout(LayoutKind.Sequential)]
        private class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseHookStruct
        {
            public POINT pt;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        #endregion

        #region 设置 Windows API
        [DllImport("user32.dll", CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            int dwThreadId
       );

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CallNextHookEx(
            IntPtr idHook,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        private static extern int ToAscii(
            int uVirtKey,
            int uScanCode,
            byte[] lpbKeyState,
            byte[] lpwTransKey,
            int fuState);
        [DllImport("user32")]
        private static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        #endregion

        #region Windows消息
        private const int WH_MOUSE_LL = 14;
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE = 7;
        private const int WH_KEYBOARD = 2;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;
        private const byte VK_SHIFT = 0x10;
        private const byte VK_CAPITAL = 0x14;
        private const byte VK_NUMLOCK = 0x90;
        #endregion

        //卸载钩子
        public UserActivityHook()
        {
            Start();
        }

        public UserActivityHook(bool InstallMouseHook, bool InstallKeyboardHook)
        {
            Start(InstallMouseHook, InstallKeyboardHook);
        }

        ~UserActivityHook()
        {
            Stop(true, true, false);
        }

        public event EventHandler<MouseExEventArgs> MouseActivity
        {
            add
            {
                this.Events.Add(EventMouseActivity, value);

            }
            remove
            {
                this.Events.Remove(EventMouseActivity, value);
            }
        }

        public event EventHandler<KeyExEventArgs> KeyDown
        {
            add
            {
                this.Events.Add(EventKeyDown, value);
            }
            remove
            {
                this.Events.Remove(EventKeyDown, value);
            }
        }

        public event EventHandler<KeyPressExEventArgs> KeyPress
        {
            add
            {
                this.Events.Add(EventKeyPress, value);
            }
            remove
            {
                this.Events.Remove(EventKeyPress, value);
            }

        }

        public event EventHandler<KeyExEventArgs> KeyUp
        {
            add
            {
                this.Events.Add(EventKeyUp, value);
            }
            remove
            {
                this.Events.Remove(EventKeyUp, value);
            }
        }

        /// <summary>
        /// 安装钩子
        /// </summary>
        public void Start()
        {
            this.Start(true, true);
        }

        /// <summary>
        /// 安装钩子（重载方法）
        /// </summary>
        /// <param installMouseHook="bool">安装鼠标</param>
        /// <param installKeyboardHook="bool">安装键盘</param>
        public void Start(bool installMouseHook, bool installKeyboardHook)
        {
            if (hMouseHook == IntPtr.Zero && installMouseHook)//如果安装鼠标的勾子
            {
                MouseHookProcedure = new HookProc(MouseHookProc);//实例化鼠标的单击操作
                //安装勾子
                hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hMouseHook == IntPtr.Zero)//如果没有安装成功
                {
                    int errorCode = Marshal.GetLastWin32Error();//返回错误代码
                    Stop(true, false, false);//卸载钩子
                    throw new Win32Exception(errorCode);//使用指定错误初始化Win32Exception类
                }
            }
            if (hKeyboardHook == IntPtr.Zero && installKeyboardHook)//如果安装键盘的勾子
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);//实例化键盘的操作
                //安装勾子
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hKeyboardHook == IntPtr.Zero)//如果没有安装成功
                {
                    int errorCode = Marshal.GetLastWin32Error();//返回错误代码
                    Stop(false, true, false);//卸载钩子
                    throw new Win32Exception(errorCode);//使用指定错误初始化Win32Exception类
                }
            }
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void Stop()
        {
            this.Stop(true, true, true);
        }

        /// <summary>
        /// 卸载钩子（重载方法）
        /// </summary>
        /// <param installMouseHook="bool">卸载鼠标</param>
        /// <param installKeyboardHook="bool">卸载键盘</param>
        public void Stop(bool uninstallMouseHook, bool uninstallKeyboardHook, bool throwExceptions)
        {
            if (hMouseHook != IntPtr.Zero && uninstallMouseHook)//如果鼠示勾子已安装
            {
                bool retMouse = UnhookWindowsHookEx(hMouseHook);//卸载钩子
                hMouseHook = IntPtr.Zero;//i清空
                if (retMouse == false && throwExceptions)//如果卸载失败
                {
                    int errorCode = Marshal.GetLastWin32Error();//返回错误代码
                    throw new Win32Exception(errorCode);//使用指定错误初始化Win32Exception类
                }
            }
            if (hKeyboardHook != IntPtr.Zero && uninstallKeyboardHook)//如果键盘勾子已安装
            {
                bool retKeyboard = UnhookWindowsHookEx(hKeyboardHook);//卸载钩子
                hKeyboardHook = IntPtr.Zero;//i清空
                if (retKeyboard == false && throwExceptions)//如果卸载失败
                {
                    int errorCode = Marshal.GetLastWin32Error();//返回错误代码
                    throw new Win32Exception(errorCode);//使用指定错误初始化Win32Exception类
                }
            }
        }

        /// <summary>
        /// 判断是否执行鼠标的单击操作
        /// </summary>
        /// <param wParam="IntPtr">鼠标键值</param>
        /// <param lParam="IntPtr">指针</param>
        private IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            EventHandler<MouseExEventArgs> handler = this.Events[EventMouseActivity] as EventHandler<MouseExEventArgs>;
            if ((nCode >= 0) && (handler != null))
            {
                MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));//定义鼠示托管对象
                MouseButtons button = MouseButtons.None;//实例化MouseButtons类，用于记录鼠标曾按下的数量
                short mouseDelta = 0;
                switch ((int)wParam)//鼠标的键值
                {
                    case WM_LBUTTONDOWN://鼠标左键
                        button = MouseButtons.Left;//记录鼠标左键的单击次数
                        break;
                    case WM_RBUTTONDOWN://鼠标右键
                        button = MouseButtons.Right;//记录鼠标右键的单击次数
                        break;
                    case WM_MOUSEWHEEL://鼠标中键
                        mouseDelta = unchecked((short)((mouseHookStruct.mouseData >> 16) & 0xffff));//获取鼠标中键的键值
                        break;
                }
                //实例化MouseExEventArgs类
                MouseExEventArgs e = new MouseExEventArgs(button, 0, mouseHookStruct.pt.x, mouseHookStruct.pt.y, mouseDelta, mouseHookStruct.flags);
                handler(this, e);//处理事件
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);//调用下一个勾子过程
        }

        /// <summary>
        /// 判断是否执行键盘的单击操作
        /// </summary>
        /// <param wParam="IntPtr">键盘的操作值</param>
        /// <param lParam="IntPtr">指针</param>
        private IntPtr KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool handled = false;
            EventHandler<KeyExEventArgs> handlerKeyDown = this.Events[EventKeyDown] as EventHandler<KeyExEventArgs>;//实例化键盘的按下操作
            EventHandler<KeyExEventArgs> handlerKeyUp = this.Events[EventKeyUp] as EventHandler<KeyExEventArgs>;//实例化键盘的松开操作
            EventHandler<KeyPressExEventArgs> handlerKeyPress = this.Events[EventKeyPress] as EventHandler<KeyPressExEventArgs>;//实例化键盘的单击操作
            //如果键盘被操作
            if ((nCode >= 0) && (handlerKeyDown != null || handlerKeyUp != null || handlerKeyPress != null))
            {
                //实例化KeyboardHookStruct类
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                //如果键盘按下
                if (handlerKeyDown != null && ((int)wParam == WM_KEYDOWN || (int)wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;//获取键值
                    KeyExEventArgs e = new KeyExEventArgs(keyData, MyKeyboardHookStruct.flags);//实例化KeyExEventArgs
                    handlerKeyDown(this, e);//执行键盘按下操作
                    handled = handled || e.Handled;//是否操作
                }
                if (handlerKeyPress != null && (int)wParam == WM_KEYDOWN)//如果单击键盘
                {
                    bool isDownShift = ((GetKeyState(VK_SHIFT) & 0x80) == 0x80 ? true : false);//判断是否为SHIFT键
                    bool isDownCapslock = (GetKeyState(VK_CAPITAL) != 0 ? true : false);//判断是否为CAPS LOCK键
                    byte[] keyState = new byte[256];//定义字节数组
                    GetKeyboardState(keyState);//获取虚拟键的当前状态
                    byte[] inBuffer = new byte[2];//定义字节数组
                    //如果可以将虚拟键转换成ASCII字符
                    if (ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags) == 1)
                    {
                        char key = (char)inBuffer[0];//获取ASCII字符
                        if ((isDownCapslock ^ isDownShift) && Char.IsLetter(key))//如果将其转换成大写
                            key = Char.ToUpper(key);//获取大写的ASCII字符
                        KeyPressExEventArgs e = new KeyPressExEventArgs(key, MyKeyboardHookStruct.flags);//实例化KeyPressExEventArgs
                        handlerKeyPress(this, e);//执行键盘单击事件
                        handled = handled || e.Handled;//是否操作
                    }
                }
                if (handlerKeyUp != null && ((int)wParam == WM_KEYUP || (int)wParam == WM_SYSKEYUP))//如果松开键盘
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;//获取键值
                    KeyExEventArgs e = new KeyExEventArgs(keyData, MyKeyboardHookStruct.flags);//实例化KeyExEventArgs类
                    handlerKeyUp(this, e);//执行键盘的松开操作
                    handled = handled || e.Handled;//是否操作
                }
            }
            if (handled)//如果不对当前进行操作
                return (IntPtr)1;
            else
                return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }

}
