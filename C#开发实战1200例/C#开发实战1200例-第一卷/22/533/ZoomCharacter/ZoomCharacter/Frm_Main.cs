using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ZoomCharacter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();							//创健控件的Graphics类
            g.Clear(Color.White);										//以指定的颜色清除控件背景
            Brush Var_Back = Brushes.Black;								//设置画刷
            FontFamily Var_FontFamily = new FontFamily("宋体");				//设置字体样式
            string Var_Str = "缩放文字";									//设置字符串
            GraphicsPath Var_Path = new GraphicsPath();						//实例化GraphicsPath对象
            //在路径中添加文本
            Var_Path.AddString(Var_Str, Var_FontFamily, (int)FontStyle.Regular, 50, new Point(0, 0), new StringFormat());
            PointF[] Var_PointS = Var_Path.PathPoints;						//获取路径中的点
            Byte[] Car_Types = Var_Path.PathTypes;							//获取相应点的类型
            Matrix Var_Matrix = new Matrix(Convert.ToSingle(textBox1.Text), 0.0F, 0.0F, Convert.ToSingle(textBox1.Text), 0.0F,
        0.0F);													//设置仿射矩阵
            Var_Matrix.TransformPoints(Var_PointS);						//设置几何变换
            GraphicsPath Var_New_Path = new GraphicsPath(Var_PointS, Car_Types);	//对GraphicsPath类进行初始化
            g.FillPath(Var_Back, Var_New_Path);							//绘制缩放的文字
        }
    }
}
