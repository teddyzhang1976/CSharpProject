using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTAreaByClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrapeziaArea myclass = new TrapeziaArea();//实例化类对象
            myclass.SD = Convert.ToDouble(textBox1.Text);//为梯形的上底赋值
            myclass.XD = Convert.ToDouble(textBox2.Text);//为梯形的下底赋值
            myclass.Height = Convert.ToDouble(textBox3.Text);//为梯形的高赋值
            textBox4.Text = myclass.Area().ToString();//计算梯形面积
        }
    }

    class Trapezia//自定义类
    {
        private double sd = 0;//定义int型变量，作为梯形的上底
        private double xd = 0;//定义int型变量，作为梯形的下底
        private double height = 0;//定义int型变量，作为梯形的高
        /// <summary>
        /// 上底
        /// </summary>
        public double SD
        {
            get
            {
                return sd;
            }
            set
            {
                sd = value;
            }
        }
        /// <summary>
        /// 下底
        /// </summary>
        public double XD
        {
            get
            {
                return xd;
            }
            set
            {
                xd = value;
            }
        }
        /// <summary>
        /// 高
        /// </summary>
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
    /// <summary>
    /// 自定义类，该类继承自Trapezia
    /// </summary>
    class TrapeziaArea : Trapezia
    {
        /// <summary>
        /// 求梯形的面积
        /// </summary>
        /// <returns>梯形的面积</returns>
        public double Area()
        {
            return (SD + XD) * Height / 2;
        }
    }
}
