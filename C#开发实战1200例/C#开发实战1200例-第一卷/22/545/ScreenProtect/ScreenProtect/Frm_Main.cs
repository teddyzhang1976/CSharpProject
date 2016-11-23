using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace ScreenProtect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int iSpeed = 2;
        private string str = "吉林省明日科技有限公司";
        private System.Drawing.Font TextStringFont = new System.Drawing.Font("宋体", 24, System.Drawing.FontStyle.Bold);
        private Color TextStringcolor = System.Drawing.Color.Red;
        private int iDistance;
        private int ixStart = 0;
        private int iyStart = 0;
        private int speed;
        private int x1, y1;
        int width1, height1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = str;
            label1.Height = label1.Font.Height;
            label1.Width = label1.Text.Length * (int)label1.Font.Size * 2;
            PlayScreenSaver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            StopScreenSaver(); 
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            StopScreenSaver(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            speed = 0;
            width1 = this.Width;
            height1 = this.Height;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ixStart == 0 && iyStart == 0)
            {
                ixStart = e.X;
                iyStart = e.Y;
                return;
            }
            else if (e.X != ixStart || e.Y != iyStart)
                StopScreenSaver();
        }

        private void PlayScreenSaver()
        {
            //下面设置文本显示框的位置坐标
            label1.Location = new System.Drawing.Point(width1 - iDistance, label1.Location.Y);
            label1.Visible = true; //设置为可见
            iDistance += iSpeed;
            if (label1.Location.X <= -(label1.Width))
            {
                iDistance = 0;
                if (label1.Location.Y == 0)
                    label1.Location = new System.Drawing.Point(label1.Location.X, height1 / 2);
                else if (label1.Location.Y == height1 / 2)
                    label1.Location = new System.Drawing.Point(label1.Location.X, height1 - label1.Height);
                else
                    label1.Location = new System.Drawing.Point(label1.Location.X, 0);
            }
            //下面是计算图片框移动坐标
            speed++;
            if (speed <= 2 * height1)
            {
                x1 = System.Math.Abs(width1 - speed);
                y1 = System.Math.Abs(height1 - speed);
            }
            else if (speed > 2 * height1 && speed <= 2 * width1)
            {
                x1 = System.Math.Abs(width1 - speed);
                y1 = System.Math.Abs(height1 - (speed - speed / height1 * height1));
            }
            else if (speed > 2 * width1 && speed <= 3 * height1)
            {
                x1 = System.Math.Abs(width1 - (speed - speed / width1 * width1));
                y1 = System.Math.Abs(height1 - (speed - speed / height1 * height1));
            }
            else if (speed > 3 * height1 && speed < 4 * height1)
            {
                x1 = System.Math.Abs(width1 - (speed - speed / width1 * width1));
                y1 = System.Math.Abs(speed - speed / height1 * height1);
            }
            else if (speed >= 4 * height1 && speed < 5 * height1)
            {
                x1 = System.Math.Abs(speed - speed / width1 * width1);
                y1 = System.Math.Abs(height1 - (speed - speed / height1 * height1));
            }
            else if (speed >= 5 * height1 && speed < 4 * width1)
            {
                x1 = System.Math.Abs(speed - speed / width1 * width1);
                y1 = System.Math.Abs(speed - speed / height1 * height1);
            }
            else if (speed >= 4 * width1 && speed < 6 * height1)
            {
                x1 = System.Math.Abs(width1 - (speed - speed / width1 * width1));
                y1 = System.Math.Abs(speed - speed / height1 * height1);
            }
            else if (speed >= 6 * height1 && speed < 5 * width1)
            {
                x1 = System.Math.Abs(width1 - (speed - speed / width1 * width1));
                y1 = System.Math.Abs(height1 - (speed - speed / height1 * height1));
            }
            else if (speed >= 5 * width1 && speed < 7 * height1)
            {
                x1 = System.Math.Abs(speed - speed / width1 * width1);
                y1 = System.Math.Abs(height1 - (speed - speed / height1 * height1));
            }
            else if (speed >= 7 * height1 && speed < 6 * width1)
            {
                x1 = System.Math.Abs(speed - speed / width1 * width1);
                y1 = System.Math.Abs(speed - speed / height1 * height1);
            }
            if (speed == 6 * width1)
                speed = 0;
            pictureBox1.Location = new System.Drawing.Point(x1, y1);
        }

        private void StopScreenSaver()
        {
            System.Windows.Forms.Cursor.Show();
            timer1.Enabled = false;
            Application.Exit();
        }
    }
}