using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MouseToDraw
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            pen = new Pen(Color.FromName("black"));//始末画笔
            graphics = CreateGraphics();//初始画板
        }

        public bool G_OnMouseDown = false;//标识，用来控制画图
        public Point lastPoint = Point.Empty;//定义绘图开始点
        public Pen pen;//声明画笔
        public Graphics graphics;//声明绘图对象

      
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastPoint.Equals(Point.Empty))//判断绘图开始点是否为空
            {
                lastPoint = new Point(e.X, e.Y);//记录鼠标当前位置
            }
            if (G_OnMouseDown)//开始绘图
            {
                Point cruuPoint = new Point(e.X, e.Y);//获取鼠标当前位置
                graphics.DrawLine(pen, cruuPoint, lastPoint);//绘图
            }
            lastPoint = new Point(e.X, e.Y);//记录鼠标当前位置
        }
        //当鼠标离开时把布尔变量设为false;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            G_OnMouseDown = false;//开始绘图标识设置为false
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            G_OnMouseDown = true;//开始绘图标识设置为true
        }
    }
}