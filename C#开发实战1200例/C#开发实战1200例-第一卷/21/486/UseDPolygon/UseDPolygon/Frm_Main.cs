using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDPolygon
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//实例化Graphics类
            Pen myPen = new Pen(Color.Black, 3);//实例化Pen类
            Point point1 = new Point(80, 20);//实例化Point类，表示第1个点
            Point point2 = new Point(40, 50);//实例化Point类，表示第2个点
            Point point3 = new Point(80, 80);//实例化Point类，表示第3个点
            Point point4 = new Point(160, 80);//实例化Point类，表示第4个点
            Point point5 = new Point(200, 50);//实例化Point类，表示第5个点
            Point point6 = new Point(160, 20);//实例化Point类，表示第6个点
            Point[] myPoints ={ point1, point2, point3, point4, point5, point6 };//创建Point结构数组
            ghs.DrawPolygon(myPen, myPoints);//调用Graphics对象的DrawPolygon方法绘制一个多边形
        }
    }
}