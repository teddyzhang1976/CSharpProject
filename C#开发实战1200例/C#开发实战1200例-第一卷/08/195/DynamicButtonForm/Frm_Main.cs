using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DynamicButtonForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button1时改变图片位置
        }
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button2时改变图片位置
        }
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button3时改变图片位置
        }
        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button4时改变图片位置
        }
        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button5时改变图片位置
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ImageAlign = ContentAlignment.MiddleCenter;//鼠标移动到button1时改变图片位置
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ImageAlign = ContentAlignment.MiddleCenter;//鼠标离开时改变button2图片位置
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ImageAlign = ContentAlignment.MiddleCenter;//鼠标离开时改变button3图片位置
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ImageAlign = ContentAlignment.MiddleCenter;//鼠标离开时改变button4图片位置
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ImageAlign = ContentAlignment.MiddleCenter;//鼠标离开时改变button5图片位置
        }
        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.ImageAlign = ContentAlignment.MiddleLeft;//鼠标移动到button6时改变图片位置
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ImageAlign = ContentAlignment.MiddleCenter;//鼠标离开时改变button6图片位置
        }
    }
}