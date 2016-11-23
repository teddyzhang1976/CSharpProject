using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraduallyBackColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            int intLocation, intHeight;//定义两个int型的变量intLocation、intHeight 
            intLocation = this.ClientRectangle.Location.Y;//为变量intLocation赋值
            intHeight = this.ClientRectangle.Height / 200;//为变量intHeight赋值
            for (int i =255; i >= 0; i--)
            {
                Color color = new Color();//定义一个Color类型的实例color
                //为实例color赋值
                color = Color.FromArgb(1, i, 100);
                SolidBrush SBrush = new SolidBrush(color);//实例化一个单色画笔类对象SBrush
                Pen pen = new Pen(SBrush, 1);//实例化一个用于绘制直线和曲线的对象pen
                e.Graphics.DrawRectangle(pen, this.ClientRectangle.X, intLocation, this.Width, intLocation + intHeight);//绘制图形
                intLocation = intLocation + intHeight;//重新为变量intLocation赋值
            }
        }
    }
}