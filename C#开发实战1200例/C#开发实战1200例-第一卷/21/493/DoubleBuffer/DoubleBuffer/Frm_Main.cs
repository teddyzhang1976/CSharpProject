using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DoubleBuffer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void PaintImage(Graphics g)
        {
            //绘图
            GraphicsPath path = new GraphicsPath(new Point[]{ new Point(100,60),new Point(350,200),new Point(105,225),new Point(190,ClientRectangle.Bottom),
                new Point(50,ClientRectangle.Bottom),new Point(50,180)}, new byte[]{
                    (byte)PathPointType.Start,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Line,
                    (byte)PathPointType.Line});
            PathGradientBrush pgb = new PathGradientBrush(path);
            pgb.SurroundColors = new Color[] { Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Orange, Color.LightBlue };
            g.FillPath(pgb, path);
            g.DrawString("明日科技欢迎您", new Font("宋体", 18, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(110, 20));
            g.DrawBeziers(new Pen(new SolidBrush(Color.Green),2),new Point[] {new Point(220,100),new Point(250,180),new Point(300,70),new Point(350,150)});
            g.DrawArc(new Pen(new SolidBrush(Color.Blue), 5), new Rectangle(new Point(250, 170), new Size(60, 60)), 0, 360);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Orange), 3), new Rectangle(new Point(240, 260), new Size(90, 50)));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap localBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            //创建位图实例
            Graphics bitmapGraphics = Graphics.FromImage(localBitmap);
            bitmapGraphics.Clear(BackColor);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            PaintImage(bitmapGraphics);
            Graphics g = e.Graphics;//获取窗体画布
            g.DrawImage(localBitmap, 0, 0); //在窗体的画布中绘画出内存中的图像
            bitmapGraphics.Dispose();
            localBitmap.Dispose();
            g.Dispose();
        }
    }
}
