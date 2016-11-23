using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DragNoFrameForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 本程序中用到的API函数
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn,int wMsg,int mParam,int lParam);//向指定的窗体发送Windows消息
        #endregion

        #region 本程序中需要声明的变量
        public const int WM_SYSCOMMAND = 0x0112;//该变量表示将向Windows发送的消息类型
        public const int SC_MOVE = 0xF010;//该变量表示发送消息的附加消息
        public const int HTCAPTION = 0x0002;//该变量表示发送消息的附加消息
        #endregion

        private void ExitContext_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出本程序
        }

        private void Frm_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
    }
}
