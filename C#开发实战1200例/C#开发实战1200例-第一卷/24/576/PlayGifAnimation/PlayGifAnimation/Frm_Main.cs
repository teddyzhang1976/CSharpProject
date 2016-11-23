using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlayGifAnimation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Bitmap bitmap = new Bitmap(Application.StartupPath + "\\1.gif");				//实例化一个GDI+绘图图面对象
        bool current = false;			//初始化一个bool型的变量current
        public void PlayImage()
        {
            if (!current) 			//当该值为true时
            {
                ImageAnimator.Animate(bitmap, new EventHandler(this.OnFrameChanged)); 	//将多帧图片显示为动画图像
                current = true; 		//设定current的值为true
            }
        }
        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate(); 			//使控件的整个图片无效并导致重绘事件
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.bitmap, new Point(1, 1)); 	//从指定的位置绘制图片
            ImageAnimator.UpdateFrames(); 					//使该帧在当前正被图画处理的所有图像中前移
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PlayImage();			//播放
            ImageAnimator.Animate(bitmap, new EventHandler(this.OnFrameChanged)); 	//将多帧图像显示为动画
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ImageAnimator.StopAnimate(bitmap, new EventHandler(this.OnFrameChanged)); 	//停止
        }
    }
}