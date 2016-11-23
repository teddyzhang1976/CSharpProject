using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetMouseFrequency
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //重写API函数
        [DllImport("user32", EntryPoint = "GetCaretBlinkTime")]
        public extern static int GetCaretBlinkTime();

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            label2.Text = GetCaretBlinkTime() + "毫秒";//显示光标闪烁频率
        }
    }
}