using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetMouseTimeSpan
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //重写API函数
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public extern static int GetDoubleClickTime();

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            label2.Text = GetDoubleClickTime()+"毫秒";//显示双击鼠标的时间间隔
        }
    }
}