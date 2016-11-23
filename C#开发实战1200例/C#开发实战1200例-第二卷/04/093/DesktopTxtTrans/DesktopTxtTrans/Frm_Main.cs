using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesktopTxtTrans
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();//获得代表整个屏幕的一个窗口（桌面窗口）句柄
        [DllImport("user32.dll")]//在窗口列表中寻找与指定条件相符的第一个子窗口
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
        [DllImport("user32.dll")]//调用一个窗口的窗口函数，将一条消息发给那个窗口
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, uint lParam);
        [DllImport("user32.dll")]//屏蔽一个窗口客户区的全部或部分区域
        public static extern int InvalidateRect(int hwnd, ref Rectangle lpRect, bool bErase);
        //声明常量
        private const int wMsg1 = 0x1026;
        private const int wMsg2 = 0x1024;
        private const uint lParam1 = 0xffffffff;
        private const uint lParam2 = 0x00ffffff;
        Rectangle lpRect = new Rectangle(0,0,0,0);

        private void button1_Click(object sender, EventArgs e)
        {
            int hwnd;
            //调用声明的API函数使桌面文字透明
            hwnd = GetDesktopWindow();
            hwnd = FindWindowEx(hwnd, 0, "Progman", null);
            hwnd = FindWindowEx(hwnd, 0, "SHELLDLL_DefView", null);
            hwnd = FindWindowEx(hwnd, 0, "SysListView32", null);
            SendMessage(hwnd, wMsg1, 0, lParam1);
            SendMessage(hwnd, wMsg2, 0, lParam2);
            InvalidateRect(hwnd, ref lpRect, true);
            MessageBox.Show("设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}