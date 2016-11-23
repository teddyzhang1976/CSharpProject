using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlMouseRange
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//限制鼠标活动区域
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);//创建Cursor对象
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);//设置鼠标位置
            Cursor.Clip = new Rectangle(this.Location, this.Size);//设置鼠标的活动区域
        }

        private void button2_Click(object sender, EventArgs e)//解除对鼠标活动区域的限制
        {
            Screen[] screens = Screen.AllScreens;//获取显示的数组
            this.Cursor = new Cursor(Cursor.Current.Handle);//创建Cursor对象
            Cursor.Clip = screens[0].Bounds;//接触对鼠标活动区域的限制
        }
    }
}