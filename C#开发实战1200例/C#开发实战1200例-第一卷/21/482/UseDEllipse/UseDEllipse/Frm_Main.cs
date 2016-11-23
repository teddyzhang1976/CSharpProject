using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDEllipse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//创建Graphics对象
            Pen myPen = new Pen(Color.DarkOrange, 3);//创建Pen对象
            graphics.DrawEllipse(myPen, 55, 20, 100, 50);//绘制椭圆
        }
    }
}