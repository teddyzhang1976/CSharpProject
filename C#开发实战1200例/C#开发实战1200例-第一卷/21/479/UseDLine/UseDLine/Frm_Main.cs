using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);//实例化Pen类
            Point point1 = new Point(10, 50);//实例化一个Point类
            Point point2 = new Point(100, 50);//再实例化一个Point类
            Graphics g = this.CreateGraphics();//实例化一个Graphics类
            g.DrawLine(blackPen, point1, point2);//调用DrawLine方法绘制直线
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//实例化Graphics类
            Pen myPen = new Pen(Color.Black, 3);//实例化Pen类
            graphics.DrawLine(myPen, 150, 30, 150, 100);//调用DrawLine方法绘制直线
        }
    }
}