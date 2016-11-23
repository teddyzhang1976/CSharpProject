using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Cachet
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        Font Var_Font = new Font("Arial", 12, FontStyle.Bold);//定义字符串的字体样式
        Rectangle rect = new Rectangle(10, 10, 160, 160);//实例化Rectangle类

        private void button1_Click(object sender, EventArgs e)
        {
            int tem_Line = 0;//记录圆的直径
            int circularity_W = 4;//设置圆画笔的粗细
            if (panel1.Width >= panel1.Height)//如果panel1控件的宽度大于等于高度
                tem_Line = panel1.Height;//设置高度为圆的直径
            else
                tem_Line = panel1.Width;//设置宽度为圆的直径
            rect = new Rectangle(circularity_W, circularity_W, tem_Line - circularity_W * 2, tem_Line - circularity_W * 2);//设置圆的绘制区域
            Font star_Font = new Font("Arial", 30, FontStyle.Regular);//设置星号的字体样式
            string star_Str = "★";
            Graphics g = this.panel1.CreateGraphics();//实例化Graphics类
            g.SmoothingMode = SmoothingMode.AntiAlias;//消除绘制图形的锯齿
            g.Clear(Color.White);//以白色清空panel1控件的背景
            Pen myPen = new Pen(Color.Red, circularity_W);//设置画笔的颜色
            g.DrawEllipse(myPen, rect); //绘制圆 
            SizeF Var_Size = new SizeF(rect.Width, rect.Width);//实例化SizeF类
            Var_Size = g.MeasureString(star_Str, star_Font);//对指定字符串进行测量
            //要指定的位置绘制星号
            g.DrawString(star_Str, star_Font, myPen.Brush, new PointF((rect.Width / 2F) + circularity_W - Var_Size.Width / 2F, rect.Height / 2F - Var_Size.Width / 2F));
            Var_Size = g.MeasureString("专用章", Var_Font);//对指定字符串进行测量
            //绘制文字
            g.DrawString("专用章", Var_Font, myPen.Brush, new PointF((rect.Width / 2F) + circularity_W - Var_Size.Width / 2F, rect.Height / 2F + Var_Size.Height * 2));
            string tempStr = "吉林省明日科技有限公司";
            int len = tempStr.Length;//获取字符串的长度
            float angle = 180 + (180 - len * 20) / 2;//设置文字的旋转角度
            for (int i = 0; i < len; i++)//将文字以指定的弧度进行绘制
            {
                //将指定的平移添加到g的变换矩阵前         
                g.TranslateTransform((tem_Line + circularity_W / 2) / 2, (tem_Line + circularity_W / 2) / 2);
                g.RotateTransform(angle);//将指定的旋转用于g的变换矩阵   
                Brush myBrush = Brushes.Red;//定义画刷
                g.DrawString(tempStr.Substring(i, 1), Var_Font, myBrush, 60, 0);//显示旋转文字
                g.ResetTransform();//将g的全局变换矩阵重置为单位矩阵
                angle += 20;//设置下一个文字的角度
            }
        }
    }
}
