using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InvertedImageCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();//创健控件的Graphics类
            g.Clear(Color.White);//以指定的颜色清除控件背景
            Brush Var_Brush_Back = Brushes.Gray;//设置前景色
            Brush Var_Brush_Fore = Brushes.Black;//设置背景色
            Font Var_Font = new Font("宋体", 40);//设置字体样式
            string Var_Str = "倒影效果的文字";//设置字符串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);//获取字符串的大小
            g.DrawString(Var_Str, Var_Font, Var_Brush_Fore, 0, 0);//绘制文本
            g.ScaleTransform(1, -1.0F);//缩放变换矩阵
            g.DrawString(Var_Str, Var_Font, Var_Brush_Back, 0, -Var_Size.Height * 1.6F);//绘制倒影文本
        }
    }
}
