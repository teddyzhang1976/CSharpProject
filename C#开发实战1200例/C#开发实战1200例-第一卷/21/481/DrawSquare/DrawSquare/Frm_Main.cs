using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawSquare
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//声明一个Graphics对象
            Pen myPen = new Pen(Color.Blue, 8);//实例化Pen类
            //调用Graphics对象的DrawRectangle方法
            graphics.DrawRectangle(myPen, 30, 10, 100, 100);
        }
    }
}