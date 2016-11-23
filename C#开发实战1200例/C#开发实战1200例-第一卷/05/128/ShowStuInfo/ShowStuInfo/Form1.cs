using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowStuInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class BStuInfo<T>
        {
            public T ID; //声明学生编号字段 
            public T Name; //声明姓名字段 
            public T Sex; //声明性别字段 
            public T Age; //声明年龄字段 
            public T Birthday; //声明生日字段 
            public T Grade; //声明班级字段
        }
        class HStuInfo<T> : BStuInfo<T>//继承自BStuInfo泛型类
        {
            public T Chinese; //声明语文成绩字段
            public T Math; //声明数学成绩字段
            public T English; //声明英语成绩字段
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HStuInfo<object> Exte = new HStuInfo<object>();//实例化派生类对象
            //通过派生类对象引用学生信息相关的字段，并为其赋值
            Exte.ID = 1;
            Exte.Name = "小王";
            Exte.Sex = "男";
            Exte.Age = 16;
            Exte.Birthday = Convert.ToDateTime("1993-11-29");
            Exte.Grade = "三年五班";
            Exte.Chinese = 145;
            Exte.Math = 140;
            Exte.English = 137;
            //将学生信息显示在TextBox文本框中
            textBox1.Text = Exte.ID.ToString();
            textBox2.Text = Exte.Name.ToString();
            textBox3.Text = Exte.Sex.ToString();
            textBox4.Text = Exte.Age.ToString();
            textBox5.Text = Exte.Birthday.ToString();
            textBox6.Text = Exte.Grade.ToString();
            textBox7.Text = Exte.Chinese.ToString();
            textBox8.Text = Exte.Math.ToString();
            textBox9.Text = Exte.English.ToString();
        }
    }
}
