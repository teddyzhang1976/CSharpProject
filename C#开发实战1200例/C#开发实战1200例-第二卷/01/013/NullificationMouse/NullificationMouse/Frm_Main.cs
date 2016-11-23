using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NullificationMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        MouseHook mouseHook = new MouseHook();
        #region 设置系统热键用到的声明
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr Hwnd, int Id, KeyModifiers keyModifiers, Keys key);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr Hwnd, int Id);

        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
        }
        #endregion

        //标识屏蔽条件
        public static bool flagL = false;
        public static bool flagR = false;
        public static bool flagM = false;

        #region 确定按钮触发的事件
        private void button1_Click(object sender, EventArgs e)
        {
            mouseHook.StartHook();
            //调用钩子后获取鼠标的按下事件
            mouseHook.MouseDown += new MouseEventHandler(Mouse_Down);
        }
        #endregion

        #region 传递鼠标事件的函数
        void Mouse_Down(object sender, MouseEventArgs e)
        {
            AddMouseValueEvent(e.Button.ToString());
        }

        public void AddMouseValueEvent(string MouseValue)
        {

        }
        #endregion

        #region 设置系统热键
        private void Form1_Load(object sender, EventArgs e)
        {
            Clipboard.Clear();
            RegisterHotKey(Handle, 100, 0, Keys.F10);
            flagL = false;
            flagR = false;
            flagM = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 100);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_Key = 0x312;
            switch (m.Msg)
            {
                case WM_Key:
                    #region 释放钩子
                    mouseHook.UnInstallHook();
                    #endregion
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        #region 各个CheckBox间的关系

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                flagL = false;
            }
            else
            {
                flagL = true;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                flagR = false;
            }
            else
            {
                flagR = true;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                flagM = false;
            }
            else
            {
                flagM = true;
            }
        }
        #endregion
    }
}
