using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetMouseNumbers
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
         public const int SM_CMOUSEBUTTONS=43;//定义一个常量值
        //重写API函数
        [DllImport("user32",EntryPoint="GetSystemMetrics")]
        public static extern int GetSystemMetrics(int intcoutn);

        private void Form1_Load(object sender, EventArgs e)
        {
            int intCon = GetSystemMetrics(SM_CMOUSEBUTTONS);//获取鼠标键数
            label2.Text = intCon + "个";//显示在Label控件中
        }
    }
}