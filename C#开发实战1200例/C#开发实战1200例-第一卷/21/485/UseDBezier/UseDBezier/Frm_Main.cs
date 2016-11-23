using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDBezier
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//实例化一个GDI+绘图图面类对象
            Pen myPen = new Pen(Color.Blue, 3);//实例化一个用于绘制直线和曲线的对象
            float startX = 50.0F;//实例化起始点的x坐标
            float startY = 80.0F;//实例化起始点的y坐标
            float controlX1 = 200.0F;//实例化第一个控制点的x坐标
            float controlY1 = 20.0F;//实例化第一个控制点的y坐标
            float controlX2 = 100.0F;//实例化第二个控制点的x坐标
            float controlY2 = 10.0F;//实例化第二个控制点的y坐标
            float endX = 190.0F;//实例化结束点的x坐标
            float endY = 40.0F;//实例化结束点的y坐标
            graphics.DrawBezier(myPen, startX, startY, controlX1, controlY1, controlX2, controlY2, endX, endY);//绘制由4个表示点的有序坐标对定义的贝塞尔样条
        }
    }
}