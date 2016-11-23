using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlockCharacter
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
            Brush Var_Brush_Back = Brushes.Black;//设置前景色
            Brush Var_Brush_Fore = Brushes.Aquamarine;//设置背景色
            Font Var_Font = new Font("宋体", 40);//设置字体样式
            string Var_Str = "印版效果的文字";//设置字符串
            SizeF Var_Size = g.MeasureString(Var_Str, Var_Font);//获取字符串的大小
            int Var_X = (panel1.Width - Convert.ToInt32(Var_Size.Width)) / 2;//设置平移的X坐标
            int Var_Y = (panel1.Height - Convert.ToInt32(Var_Size.Height)) / 2;////设置平移的Y坐标
            //实现印版文字
            for (int i = 0; i < 10; i++)
            {
                g.DrawString(Var_Str, Var_Font, Var_Brush_Back, Var_X - i, Var_Y + i);
            }
            g.DrawString(Var_Str, Var_Font, Var_Brush_Back, Var_X, Var_Y);//绘制文字
        }
    }
}
