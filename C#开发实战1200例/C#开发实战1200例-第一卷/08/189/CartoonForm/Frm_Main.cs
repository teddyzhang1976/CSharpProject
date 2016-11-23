using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CartoonForm
{
    public partial class Frm_Main : Form
    {
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000; 
        public Frm_Main()
        {
            InitializeComponent();
            AnimateWindow(this.Handle, 3000, AW_SLIDE + AW_VER_NEGATIVE);//开始窗体动画
        }

        //重写API函数，用来执行窗体动画显示操作
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 3000, AW_SLIDE + AW_VER_NEGATIVE + AW_HIDE);//结束窗体动画
        }
    }
}