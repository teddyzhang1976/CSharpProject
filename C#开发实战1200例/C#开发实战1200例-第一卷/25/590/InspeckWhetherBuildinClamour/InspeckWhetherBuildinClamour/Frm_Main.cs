using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InspeckWhetherBuildinClamour
{
    public partial class Frm_Main : Form
    {
        [DllImport("winmm.dll", EntryPoint = "waveOutGetNumDevs")]
        public static extern int waveOutGetNumDevs();
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            if (waveOutGetNumDevs() != 0) 	//当安装声卡时
            { this.radioButton1.Select(); }	//设定radioButton1按钮为选定状态
            else					//当没有安装声卡时
            { this.radioButton2.Select(); }	//设定radioButton2按钮为选定状态
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}