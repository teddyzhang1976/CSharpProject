using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace DrawPlane
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        Graphics g;//创建Graphics对象
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bt = new Bitmap(panel1.Width, panel1.Height);//实例化一个Bitmap对象
            int flag = (panel1.Width-4 )/ 6;//X轴的增值
            g = Graphics.FromImage(bt);//实例化Graphics对象
            Pen p = new Pen(Color.Black, 1);//设置Pen对象
            g.DrawLine(p, new Point(0, 0), new Point(0, panel1.Height-20));//绘制Y轴
            g.DrawLine(p, new Point(0, panel1.Height - 20), new Point(panel1.Width - 4, panel1.Height - 20));//绘制X轴
            //声明一个用于绘制颜色的数组
            Color[] cl = new Color[] { Color.Red, Color.Blue, Color.YellowGreen, Color.Yellow, Color.RoyalBlue, Color.Violet, Color .Tomato};
            int[] points = { 20,70,80,60,40,100,10};//声明一个计算走势峰值的数组
            Point pt1 = new Point(0, panel1.Height - 20 - points[0]);//记录绘制四边形的第一个点
            Point pt2 = new Point(0, panel1.Height - 20);//记录绘制四边形的第二个点
            for (int i = 0; i <= 6; i++)//通过for循环绘制月份和面形图
            {
                PointF p1 = new PointF(flag * i, panel1.Height - 20);//计算每个月份数字的坐标
                //绘制显示月份的数字
                g.DrawString(i.ToString(), new Font("宋体", 9), new SolidBrush(Color.Black), new PointF(p1.X - 2, p1.Y));
                //记录绘制四边形的第三个点
                Point pt3 = new Point(flag * i, panel1.Height - 20);
                //记录绘制四边形的第四个点
                Point pt4 = new Point(flag * i, panel1.Height - 20 - points[i]);
                Point[] pt={pt1,pt2,pt3,pt4};//声明一个Point数组
                g.FillPolygon(new SolidBrush(cl[i]), pt);//填充四边形的颜色
                //当继续绘制下一个四边形时，前一个四边形的最后两个点作为下一个四边形的起始点
                pt1 = pt4;
                pt2 = pt3;
            }
            panel1.BackgroundImage = bt;//显示绘制的面形图
        }
    }
}
