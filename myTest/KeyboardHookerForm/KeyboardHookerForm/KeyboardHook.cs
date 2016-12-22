using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;


namespace KeyboardHookerForm
{
    /// <summary>

    /// 键盘钩子

    /// [以下代码来自某网友，并由小序改造加强]

    /// </summary>

    class KeyboardHook
    {

        public event KeyEventHandler KeyDownEvent;

        public event KeyPressEventHandler KeyPressEvent;

        public event KeyEventHandler KeyUpEvent;

        public event MouseEventHandler MouseDownDouble;

        public event MouseEventHandler MouseDown;

        public event MouseEventHandler MouseDownRight;

        public event MouseEventHandler Mousemov;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        static int hKeyboardHook = 0; //声明键盘钩子处理的初始值
        static int hMouseHook = 0;//申明鼠标钩子处理的初始值

        //值在Microsoft SDK的Winuser.h里查询

        public const int WH_KEYBOARD_LL = 13;   //线程键盘钩子监听鼠标消息设为2，全局键盘监听鼠标消息设为13

        HookProc KeyboardHookProcedure; //声明KeyboardHookProcedure作为HookProc类型
        HookProc MouseHookProceduremz; //声明MouseHookProcedure作为HookProc类型

        //键盘结构

        [StructLayout(LayoutKind.Sequential)]

        public class KeyboardHookStruct
        {

            public int vkCode;  //定一个虚拟键码。该代码必须有一个价值的范围1至254

            public int scanCode; // 指定的硬件扫描码的关键

            public int flags;  // 键标志

            public int time; // 指定的时间戳记的这个讯息

            public int dwExtraInfo; // 指定额外信息相关的信息

        }

        //使用此功能，安装了一个钩子

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention =

CallingConvention.StdCall)]

        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,

IntPtr hInstance, int threadId);



        //调用此函数卸载钩子

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention =

CallingConvention.StdCall)]

        public static extern bool UnhookWindowsHookEx(int idHook);



        //使用此功能，通过信息钩子继续下一个钩子

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention =

CallingConvention.StdCall)]

        public static extern int CallNextHookEx(int idHook, int nCode, Int32

wParam, IntPtr lParam);


        // 取得当前线程编号（线程钩子需要用到）

        [DllImport("kernel32.dll")]

        static extern int GetCurrentThreadId();


        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效

        [DllImport("kernel32.dll")]

        public static extern IntPtr GetModuleHandle(string name);


        public void Start()
        {
            //安装鼠标钩子
            if (hMouseHook == 0)
            {
                MouseHookProceduremz = new HookProc(MouseHookProcedure);
                hMouseHook = SetWindowsHookEx(14, MouseHookProceduremz,

  Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

                if (hMouseHook == 0)
                {

                    Stopmouse();

                    MessageBox.Show("安装鼠标钩子失败");

                }
            }

            // 安装键盘钩子

            if (hKeyboardHook == 0)
            {

                KeyboardHookProcedure = new HookProc(KeyboardHookProc);

                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL,

KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
                // hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL,  KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

                //键盘线程钩子

                // SetWindowsHookEx( 2,KeyboardHookProcedure, IntPtr.Zero, GetCurrentThreadId());//指定要监听的线程idGetCurrentThreadId(),

                //键盘全局钩子,需要引用空间(using System.Reflection;) 
                //关于SetWindowsHookEx (int idHook, HookProc lpfn, IntPtr hInstance, int threadId)函数将钩子加入到钩子链表中，说明一下四个参数：

                //idHook 钩子类型，即确定钩子监听何种消息，上面的代码中设为2，即监听键盘消息并且是线程钩子，如果是全局钩子监听键盘消息应设为13，

                //线程钩子监听鼠标消息设为7，全局钩子监听鼠标消息设为14。lpfn钩子子程的地址指针。如果dwThreadId参数为0 或是一个由别的进程创建的

                //线程的标识，lpfn必须指向DLL中的钩子子程。 除此以外，lpfn可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子钩到任何

                //消息后便调用这个函数。hInstance应用程序实例的句柄。标识包含lpfn所指的子程的DLL。如果threadId 标识当前进程创建的一个线程，而且子

                //程代码位于当前进程，hInstance必须为NULL。可以很简单的设定其为本应用程序的实例句柄。threadId 与安装的钩子子程相关联的线程的标识符

                //如果为0，钩子子程与所有的线程关联，即为全局钩子

                //如果SetWindowsHookEx失败

                if (hKeyboardHook == 0)
                {

                    Stop();

                    MessageBox.Show("安装键盘钩子失败");

                }
                else
                    MessageBox.Show("键盘hook成功");

            }

        }

        private void Stopmouse()
        {
            bool retKeyboard = true;

            if (hMouseHook != 0)
            {

                retKeyboard = UnhookWindowsHookEx(hMouseHook);

                hMouseHook = 0;

            }
            if (!(retKeyboard)) MessageBox.Show("卸载鼠标钩子失败");
        }

        #region 鼠标钩子结构体
        //声明一个Point的封送类型 
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        //声明鼠标钩子的封送结构类型 
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        //定义鼠标常熟
        private const int WM_MOUSEMOVE = 0x200;//鼠标移动 512（int）
        private const int WM_LBUTTONDOWN = 0x201;//鼠标左键 513（int）
        private const int WM_RBUTTONDOWN = 0x204;//鼠标右键 516（int）
        private const int WM_MBUTTONDOWN = 0x207;//鼠标中健 519（int）
        private const int WM_LBUTTONUP = 0x202;//左键弹起 514（int）
        private const int WM_RBUTTONUP = 0x205;//右键弹起 517（int）
        private const int WM_MBUTTONUP = 0x208;//中健弹起 520（int）
        private const int WM_LBUTTONDBLCLK = 0x203;//双击左键 515（int）
        private const int WM_RBUTTONDBLCLK = 0x206;//双击右键 518（int）
        private const int WM_MBUTTONDBLCLK = 0x209;//双击中健 521（int）
        #endregion
        private int MouseHookProcedure(int nCode, int wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (MouseDown != null || MouseDownDouble != null

|| Mousemov != null || MouseDownRight != null))
            {

                MouseButtons button = MouseButtons.None;
                int clickCount = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONUP:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONDBLCLK:
                        button = MouseButtons.Left;
                        clickCount = 2;
                        break;
                    case WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONUP:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONDBLCLK:
                        button = MouseButtons.Right;
                        clickCount = 2;
                        break;
                }
                MouseHookStruct MyMouseHookStruct = (MouseHookStruct)

Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                MouseEventArgs e = new MouseEventArgs(button, clickCount,

MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
                // raise KeyDown

                if (MouseDown != null && wParam == WM_LBUTTONDOWN)//单击事件
                {
                    MouseDown(this, e);
                }
                if (this.MouseDownDouble != null && wParam ==

WM_LBUTTONDBLCLK)//双击事件
                {
                    MouseDownDouble(this, e);
                }
                if (this.Mousemov != null && wParam == WM_LBUTTONDOWN && wParam

== WM_MOUSEMOVE) //拖动事件
                {
                    Mousemov(this, e);
                }
                if (this.MouseDownRight != null && wParam == WM_RBUTTONDOWN)
                {
                    MouseDownRight(this, e);
                }

            }


            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，  也就是传给消息真正的接受者
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        public void Stop()
        {

            bool retKeyboard = true;

            if (hKeyboardHook != 0)
            {

                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);

                hKeyboardHook = 0;

            }

            if (!(retKeyboard)) MessageBox.Show("卸载键盘钩子失败");

        }

        //ToAscii职能的转换指定的虚拟键码和键盘状态的相应字符或字符

        [DllImport("user32")]

        public static extern int ToAscii(int uVirtKey, //[in] 指定虚拟关键代码进行翻译。

                                         int uScanCode, // [in] 指定的硬件扫描码的关键须翻译成英文。高阶位的这个值设定的关键，如果是（不压）

                                         byte[] lpbKeyState, // [in] 指针，以256字节数组，包含当前键盘的状态。每个元素（字节）的数组包含状态的一个关键。如果

//高阶位的字节是一套，关键是下跌（按下）。在低比特，如果设置表明，关键是对切换。

//在此功能，只有肘位的CAPS LOCK键是相关的。在切换状态的NUM个锁和滚动锁定键被忽略。

                                         byte[] lpwTransKey, // [out] 指针的缓冲区收到翻译字符或字符。

                                         int fuState); // [in] Specifies   whether a menu is active.This parameter must be 1 if a menu is active, or 0'otherwise.


        //获取按键的状态

        [DllImport("user32")]

        public static extern int GetKeyboardState(byte[] pbKeyState);



        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention =

CallingConvention.StdCall)]

        private static extern short GetKeyState(int vKey);


        private const int WM_KEYDOWN = 0x100;//KEYDOWN

        private const int WM_KEYUP = 0x101;//KEYUP

        private const int WM_SYSKEYDOWN = 0x104;//SYSKEYDOWN

        private const int WM_SYSKEYUP = 0x105;//SYSKEYUP


        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {

            // 侦听键盘事件
            
            if ((nCode >= 0) && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                MessageBox.Show("keyboard press down scancode = 0x" + Convert.ToString(MyKeyboardHookStruct.scanCode, 16));
                // raise KeyDown

                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam ==

WM_SYSKEYDOWN))
                {

                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;

                    KeyEventArgs e = new KeyEventArgs(keyData);

                    KeyDownEvent(this, e);

                }


                //键盘按下

                if (KeyPressEvent != null && wParam == WM_KEYDOWN)
                {

                    byte[] keyState = new byte[256];

                    GetKeyboardState(keyState);
                    

                    byte[] inBuffer = new byte[2];

                    if (ToAscii(MyKeyboardHookStruct.vkCode,

MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags)

== 1)
                    {
                        
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);

                        KeyPressEvent(this, e);

                    }

                }


                // 键盘抬起

                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam ==

WM_SYSKEYUP))
                {

                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;

                    KeyEventArgs e = new KeyEventArgs(keyData);

                    KeyUpEvent(this, e);

                }


            }

            
            //如果返回1，则结束消息，这个消息到此为止，不再传递。

            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者

            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);

        }

        ~KeyboardHook()
        {

            Stop();

        }

    }
}
