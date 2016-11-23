using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChangeRLKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        public extern static int SwapMouseButton(int bSwap);//重写API函数
        
        public void DefaultRightButton()
        {
            SwapMouseButton(1);//鼠标右键
        }
        
        public void DefaultLeftButton()
        {
            SwapMouseButton(0);//鼠标左键
        }
        
        private void btnChange_Click(object sender, EventArgs e)
        {
            this.DefaultRightButton();//交换鼠标左右键
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.DefaultLeftButton();//恢复默认设置
        }
    }
}