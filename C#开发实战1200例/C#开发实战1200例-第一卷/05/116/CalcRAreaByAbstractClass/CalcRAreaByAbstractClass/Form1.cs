using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcRAreaByAbstractClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcArea calcArea = new CalcArea();//实例化派生类
            Roll roll = calcArea;//使用派生类对象实例化抽象类
            string strNum=textBox1.Text.Trim();//记录TextBox文本框中的内容
            if (strNum != "")//判断是否输入了圆半径
            {
                try
                {
                    roll.R = int.Parse(strNum );//使用抽象类对象访问抽象类中的半径属性
                    textBox2.Text = roll.Area().ToString();//调用自定义方法进行求圆面积
                }
                catch 
                {
                    MessageBox.Show("请输入正确的圆半径！");
                }
            }
        }
    }
    public abstract class Roll
    {
        private int r = 0;
        /// <summary>
        /// 圆半径
        /// </summary>
        public int R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
        /// <summary>
        /// 抽象方法，用来计算圆面积
        /// </summary>
        public abstract double Area();
    }
    public class CalcArea : Roll//继承抽象类
    {
        /// <summary>
        /// 重写抽象类中计算圆面积的方法
        /// </summary>
        public override double Area()
        {
            return Math.PI * R * R;
        }
    }
}
