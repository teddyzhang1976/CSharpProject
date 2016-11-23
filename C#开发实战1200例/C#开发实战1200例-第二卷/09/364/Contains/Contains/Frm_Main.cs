using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contains
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<Person> People = new List<Person>();//创建人员列表
            for (int i = 1; i < 10; i++)
            {
                People.Add(new Person(i, "User0" + i.ToString()));
            }
            bool result = People.Contains(new Person(3, "User03"));//检查序列是否包含指定元素
            //显示查询结果
            label1.Text = "数据源：People(包含9个元素,元素的ID值分别为1、2、3、......、9)";//数据源
            label2.Text = "查询表达式：Contains(new Person(3,\"User03\"))";//查询表达式/操作
            label3.Text = "查询结果："+result.ToString();//查询结果
        }
    }
    public class Person
    {
        public Person(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }//人员ID
        public string Name { get; set; }//人员名称
    }
}
