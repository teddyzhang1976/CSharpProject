using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SBCorDBC
{
    class controlIme
    {
        //声明一些API函数
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr Hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr Himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr Himc, bool b1);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr Himc, ref int lp, ref int lp2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr Hwnd, int lnHotkey);
        public const int IME_CMODE_FULLSHAPE = 0x8;
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        public static void SetIme(Control ctl)
        {
            ChangeControl(ctl);
        }

        private static void ChangeControl(Control ctl)
        {
            //在控件的Click事件中触发来调整输入法状态
            ctl.Click += new EventHandler(ctl_Click);
        }

        //控件的Click处理程序
        public static void ctl_Click(object sender, EventArgs e)
        {
            ChangeControlIState(sender);
        }
        private static void ChangeControlIState(object sender)
        {
            Control ctl = (Control)sender;
            ChangeControlIState(ctl.Handle);
        }

        //检查输入法的全角半角状态
        public static void ChangeControlIState(IntPtr h)
        {
            IntPtr HIme = ImmGetContext(h);
            if (ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                    {
                        iMode &= (~IME_CMODE_FULLSHAPE);
                        ImmSimulateHotKey(h, IME_CHOTKEY_SHAPE_TOGGLE);    //转换成半角
                    }
                    else
                    {
                        ImmSimulateHotKey(h, IME_CHOTKEY_SHAPE_TOGGLE);    //转换成全角
                    }
                }
            }
        }
    }
}
