using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SnatchAtMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void Frm_Main_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();//创建窗体的Graphics类
            Cursor.Draw(myGraphics, new Rectangle(e.X, e.Y, 10, 10));//调用Cursor类的Draw方法抓取鼠标形状
        }
    }
}