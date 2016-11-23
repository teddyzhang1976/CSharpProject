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

namespace SetAnimateMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32", EntryPoint = "LoadCursorFromFile")]
        public static extern int IntLoadCursorFromFile(string lpFileName);

        [DllImport("user32", EntryPoint = "SetSystemCursor")]
        public static extern void SetSystemCursor(int hcur, int i);

        const int OCR_NORAAC = 32512;//标准
        const int OCR_HAND = 32649;//手
        const int OCR_NO = 32648;//斜的圆
        const int OCR_SIZEALL = 32646;//移动

        private void ToolS_From_Click(object sender, EventArgs e)
        {
            Cursor myCursor = new Cursor(Cursor.Current.Handle);
            IntPtr colorCursorHandle = LoadCursorFromFile("0081.ani");//鼠标图标路径
            myCursor.GetType().InvokeMember("handle", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, myCursor, new object[] { colorCursorHandle });
            this.Cursor = myCursor;
        }

        private void ToolS_FromRevert_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ToolS_System_Click(object sender, EventArgs e)
        {
            //将要修改的标鼠图片存入到系统的WINDOWS\Cursors目录下
            //设置正常选择鼠标
            int cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\01.cur");
            SetSystemCursor(cur, OCR_NORAAC);
            //设置移动
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\03.cur");
            SetSystemCursor(cur, OCR_SIZEALL);
            //设置不可用
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\04.cur");
            SetSystemCursor(cur, OCR_NO);
            //设置超链接
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\06.cur");
            SetSystemCursor(cur, OCR_HAND);

        }

        private void ToolS_SystemRevert_Click(object sender, EventArgs e)
        {
            //恢复正常选择鼠标
            int cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\arrow_m.cur");
            SetSystemCursor(cur, OCR_NORAAC);
            //恢复移动
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\move_r.cur");
            SetSystemCursor(cur, OCR_SIZEALL);
            //恢复不可用
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\no_r.cur");
            SetSystemCursor(cur, OCR_NO);
            //恢复超链接
            cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\hand.cur");
            SetSystemCursor(cur, OCR_HAND);
        }
    }
}
