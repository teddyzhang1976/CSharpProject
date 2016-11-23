using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ShadeCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();						//创健控件的Graphics类
            g.Clear(Color.White);									//以指定的颜色清除控件背景
            Color Var_Color_Up = Color.Red;							//设置前景色
            Color Var_Color_Down = Color.Yellow;						//设置背景色
            Font Var_Font = new Font("宋体", 40);						//设置字体样式
            string Var_Str = "渐变效果的文字";						//设置字符串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);			//获取字符串的大小
            PointF Var_Point = new PointF(5, 5);						//设置文字的显示位置
            RectangleF Var_Rect = new RectangleF(Var_Point, Var_Size);		//根据文字的大小及位置，实例化RectangleF类
            LinearGradientBrush Var_LinearBrush = new LinearGradientBrush(Var_Rect, Var_Color_Up, Var_Color_Down,
        LinearGradientMode.Horizontal);								//设置从左到右的线性渐变效果
            g.DrawString(Var_Str, Var_Font, Var_LinearBrush, Var_Point);	//绘制文字
        }
    }
}
