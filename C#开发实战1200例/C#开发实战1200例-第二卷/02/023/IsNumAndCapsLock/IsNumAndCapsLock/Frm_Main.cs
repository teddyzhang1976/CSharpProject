using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IsNumAndCapsLock
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //重写API函数
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "GetKeyState")]
        public static extern int GetKeyState(int intkey);

        private void button1_Click(object sender, EventArgs e)
        {
            string strChenk = "判断NumLock键和CapsLock键是否锁定:\n";
            int intNumLock = GetKeyState(144);//判断NumLock键
            if (intNumLock == 0)
            {
                strChenk += "NumLock键未锁定\n";
            }
            else
            {
                strChenk += "NumLock键已锁定\n";
            }
            int intCapsLock = GetKeyState(20);//判断CapsLock键
            if (intCapsLock == 0)
            {
                strChenk += "CapsLock键未锁定\n";
            }
            else
            {
                strChenk += "CapsLock键已锁定\n";
            }
            MessageBox.Show(strChenk, "判断NumLock键和CapsLock键是否锁定");
        }
    }
}