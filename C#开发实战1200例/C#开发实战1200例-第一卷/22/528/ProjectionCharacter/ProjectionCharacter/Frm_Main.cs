using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjectionCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();//实例化panel1控件的Graphics类
            g.Clear(Color.White);//以白色清空panel1的背景
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//设置文本输出的质量
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除绘制时出现的锯齿
            Font Var_Font = new Font("宋体", 48);//定义文字的字体
            Matrix Var_Matrix = new Matrix();//实例化Matrix类
            Var_Matrix.Shear(-1.4F, 0.0F);//设置投影
            Var_Matrix.Scale(1, 0.5F);//设置缩放
            Var_Matrix.Translate(168, 118);//设置平移
            g.Transform = Var_Matrix;//设置坐标平面变换
            SolidBrush Var_Brush_1 = new SolidBrush(Color.Gray);//设置文字的画刷
            SolidBrush Var_Brush_2 = new SolidBrush(Color.SlateBlue);//设置投影的画刷
            string Var_Str = "投影效果文字";//设置文字
            g.DrawString(Var_Str, Var_Font, Var_Brush_1, new PointF(0, 60));//绘制投影
            g.ResetTransform();//变换矩阵重置为单位矩阵
            g.DrawString(Var_Str, Var_Font, Var_Brush_2, new PointF(0, 60));//绘制文字
        }
    }
}
