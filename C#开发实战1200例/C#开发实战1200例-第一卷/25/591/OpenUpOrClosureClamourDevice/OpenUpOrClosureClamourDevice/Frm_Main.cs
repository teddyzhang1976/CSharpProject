using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OpenUpOrClosureClamourDevice
{
    public partial class Frm_Main : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, System.UInt16 uReturnLength, System.IntPtr HwndCallback);
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mciSendString("Set cdaudio door open wait", "", 0, this.Handle); 	//打开CD_ROM
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mciSendString("Set cdaudio door closed wait", "", 0, this.Handle); 	//关闭CD_ROM
        }
    }
}