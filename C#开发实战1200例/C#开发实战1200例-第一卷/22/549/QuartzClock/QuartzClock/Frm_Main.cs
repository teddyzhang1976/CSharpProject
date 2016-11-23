using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace QuartzClock
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Point mouseOffset;
        private bool isMouseDown = false;


        private void clock(Graphics g)
        {
            const double pi = Math.PI;
            Point center = new Point(0, 0);
            DateTime time = DateTime.Now;
            //读取时间；
            double sec = 2.0 * pi * time.Second / 60.0;
            double min = 2.0 * pi * (time.Minute + time.Second / 60.0) / 60.0;
            double hour= 2.0 * pi * (time.Hour + time.Minute / 60.0) / 12.0;
            //各指针单位换算；
            int r = Math.Min(pictureBox1.Image.Width, pictureBox1.Image.Height) / 2;
            int secHandLength = (int)(0.55 * r);
            int minHandLength = (int)(0.55 * r);
            int hourHandLength = (int)(0.45 * r);
            //刷新指针；
            Pen SPen = new Pen(Color.White, 1);
            g.DrawLine(SPen, center, new Point((int)(secHandLength * Math.Sin(sec)),
             (int)(-secHandLength * Math.Cos(sec))));
            Pen MPen = new Pen(Color.White, 2);
            g.DrawLine(MPen, center, new Point((int)(minHandLength * Math.Sin(min)),
             (int)(-minHandLength * Math.Cos(min))));
            Pen HPen = new Pen(Color.White, 2);
            g.DrawLine(HPen, center, new Point((int)(hourHandLength * Math.Sin(hour)),
             (int)(-hourHandLength * Math.Cos(hour))));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();    
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = (Image)Properties.Resources.bg;
            Image a = pictureBox1.Image;
            Graphics g = Graphics.FromImage(a);
            g.TranslateTransform(pictureBox1.Image.Width / 2, pictureBox1.Image.Height / 2, MatrixOrder.Append);
            clock(g);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void 前端显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (前端显示ToolStripMenuItem.Checked == true)
            {
                前端显示ToolStripMenuItem.Checked = false;
                this.TopMost = false;
            }
            else
            {
                前端显示ToolStripMenuItem.Checked = true;
                this.TopMost = true;
            }
        }

        private void 隐藏时钟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 显示时钟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
