using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetRAreaByStruct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Rect//定义一个矩形结构
        {
            public double width;//矩形的宽
            public double height;//矩形的高
            /// <summary>
            /// 构造函数，初始化矩形的宽和高
            /// </summary>
            /// <param name="x">矩形的宽</param>
            /// <param name="y">矩形的高</param>
            public Rect(double x, double y)
            {
                width = x;
                height = y;
            }
            /// <summary>
            /// 计算矩形面积
            /// </summary>
            /// <returns>矩形面积</returns>
            public double Area()
            {
                return width * height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //使用自定义构造函数实例化矩形结构
            Rect myRect = new Rect(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
            textBox3.Text = myRect.Area().ToString();//计算矩形的面积
        }
    }
}
