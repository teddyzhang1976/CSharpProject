using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtensiveList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Types<T>
        {
            public T Num; //声明编号字段 
            public T Name; //声明姓名字段 
            public T Sex; //声明性别字段 
            public T Age; //声明年龄字段 
            public T Birthday; //声明生日字段 
            public T Salary; //声明薪水字段 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Types<object> Exte = new Types<object>();//实例化泛型类对象
            //为泛型类中声明的字段进行赋值，存储不同类型的值
            Exte.Num = 1;
            Exte.Name = "王老师";
            Exte.Sex = "男";
            Exte.Age = 25;
            Exte.Birthday = Convert.ToDateTime("1986-06-08");
            Exte.Salary = 1500.45F;
            //将泛型类中各字段的值显示在文本框中
            textBox1.Text = Exte.Num.ToString();
            textBox2.Text = Exte.Name.ToString();
            textBox3.Text = Exte.Sex.ToString();
            textBox4.Text = Exte.Age.ToString();
            textBox5.Text = Exte.Birthday.ToString();
            textBox6.Text = Exte.Salary.ToString();
        }
    }
}
