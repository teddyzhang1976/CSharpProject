using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenCutter
{
    public partial class Frm_Browser : Form
    {
        public Frm_Browser()
        {
            InitializeComponent();
        }
        public Image ig;
        private Graphics MainPainter;
        private Pen pen;
        private bool isDowned;
        private Image baseImage;
        private Rectangle Rect;
        private bool RectReady;
        private Point downPoint;
        private bool change;
        Rectangle[] Rectpoints;
        int point;
        int tmpx;
        int tmpy;

        private void DrawRect(Graphics Painter, int Mouse_x, int Mouse_y)
        {
            int width = 0;
            int heigth = 0;
            if (Mouse_y < Rect.Y)
            {
                Rect.Y = Mouse_y;
                heigth = downPoint.Y - Mouse_y;
            }
            else
            {
                heigth = Mouse_y - downPoint.Y;
            }
            if (Mouse_x < Rect.X)
            {
                Rect.X = Mouse_x;
                width = downPoint.X - Mouse_x;
            }
            else
            {
                width = Mouse_x - downPoint.X;
            }
            Rect.Size = new Size(width, heigth);
            DrawRects(Painter);
        }
        private void DrawRects(Graphics Painter)
        {
            Painter.DrawRectangle(pen, Rect);
        }

        private Image DrawScreen(Image back, int Mouse_x, int Mouse_y)
        {
            Graphics Painter = Graphics.FromImage(back);
            DrawRect(Painter, Mouse_x, Mouse_y);
            return back;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = ig;
            this.WindowState = FormWindowState.Maximized;
            MainPainter = this.CreateGraphics();
            pen = new Pen(Brushes.Red);
            isDowned = false;
            baseImage = this.BackgroundImage;
            Rect = new Rectangle();
            RectReady = false;
            change = false;
            Rectpoints = new Rectangle[8];
            for (int i = 0; i < Rectpoints.Length; i++)
            {
                Rectpoints[i].Size = new Size(4, 4);
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left && Rect.Contains(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y))
            {
                Image memory = new Bitmap(Rect.Width-1, Rect.Height-1);
                Graphics g = Graphics.FromImage(memory);
                g.CopyFromScreen(Rect.X+1, Rect.Y+1,0, 0, Rect.Size);
                Clipboard.SetImage(memory);
                this.Close();
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDowned = true;
                if (RectReady == true)
                {
                    tmpx = e.X;
                    tmpy = e.Y;
                }
                else
                {
                    Rect.X = e.X;
                    Rect.Y = e.Y;
                    downPoint = new Point(e.X, e.Y);
                }
                for (int i = 0; i < Rectpoints.Length; i++)
                {
                    if (Rectpoints[i].Contains(e.X, e.Y))
                    {
                        change = true;
                        point = i + 1;
                    }
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                if (RectReady != true)
                {
                    this.Close();
                    return;
                }
                this.CreateGraphics().DrawImage(baseImage, 0, 0);
                RectReady = false;
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDowned = false;
                RectReady = true;
                change = false;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (RectReady == true)
            {
                if (Rect.Contains(e.X, e.Y))
                {
                    if (isDowned == true && change == false)
                    {
                        //和上一次的位置比较获取偏移量
                        Rect.X = Rect.X + e.X - tmpx;
                        Rect.Y = Rect.Y + e.Y - tmpy;
                        //记录现在的位置
                        tmpx = e.X;
                        tmpy = e.Y;
                        MoveRect((Image)baseImage.Clone(), Rect);
                    }
                }
                //if (change == true && isDowned == true)
                //{
                //    if (point == 6)
                //    {
                //        ChangeRect((Image)baseImage.Clone(), e.X, e.Y, ChangeSide.RightTop);
                //    }
                //    if (point == 7)
                //    {
                //        ChangeRect((Image)baseImage.Clone(), e.X, e.Y, ChangeSide.Right);
                //    }
                //    if (point == 8)
                //    {
                //        ChangeRect((Image)baseImage.Clone(), e.X, e.Y, ChangeSide.RightBottom);
                //    }
                //}
            }
            else
            {
                if (isDowned == true)
                {
                    Image New = DrawScreen((Image)baseImage.Clone(), e.X, e.Y);
                    MainPainter.DrawImage(New, 0, 0);
                    New.Dispose();
                }
            }
        }

        private void MoveRect(Image image, Rectangle Rect)
        {
            Graphics Painter = Graphics.FromImage(image);
            Painter.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
            DrawRects(Painter);
            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        private void ChangeRect(Image image, int Position_x, int Position_y, ChangeSide Side)
        {
            Graphics Painter = Graphics.FromImage(image);
            switch (Side)
            {
                case ChangeSide.Left:
                    break;
                case ChangeSide.LeftBottom:
                    break;
                case ChangeSide.LeftTop:
                    Rect.Y = Position_y;
                    break;
                case ChangeSide.Bottom:
                    break;
                case ChangeSide.Top:
                    break;
                case ChangeSide.Right:
                    if (Position_x < Rect.X)
                    {
                        Rect.Size = new Size(tmpx - Position_x + Rect.Width, Rect.Height);
                        Rect.X = Position_x;
                        //记录现在的位置
                        tmpx = Position_x;
                    }
                    else
                        Rect.Size = new Size(Position_x - Rect.X, Rect.Height);
                    break;
                case ChangeSide.RightBottom:
                    Rect.Size = new Size(Position_x - Rect.X, Position_y - Rect.Y);
                    break;
                case ChangeSide.RightTop:
                    Rect.Size = new Size(Position_x - Rect.X, Rect.Height + Rectpoints[5].Y - Position_y);
                    break;
            }
            DrawRects(Painter);
            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        enum ChangeSide
        {
            Left,
            LeftTop,
            LeftBottom,
            Right,
            RightTop,
            RightBottom,
            Top,
            Bottom
        }

        struct myRect
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Rectangle[] RectPoints;

            public void Init(int x, int y, int width, int height, int number)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                RectPoints = new Rectangle[number];
            }
        }
    }
}
