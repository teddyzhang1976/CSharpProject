using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlFormMove
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Frm_Main form1 = new Frm_Main();//创建窗体对象
            form1.KeyPreview = true;//设置窗体接收按键事件
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point point = this.Location;//定义一个标识窗体的变量
            switch (e.KeyData)//判断按键类型
            {
                case Keys.Up://当按键为上方向键时
                    point.Y -= 2;
                    break;
                case Keys.Down://当按键为下方向键时
                    point.Y += 2;
                    break;
                case Keys.Right://当按键为右方向键时
                    point.X += 2;
                    break;
                case Keys.Left://当按键为左方向键时
                    point.X -= 2;
                    break;
                case Keys.Escape://当按键为Esc键时
                    this.Close();//关闭本窗体
                    break;
                default: break;
            }
            this.Location = point;
        }
    }
}
