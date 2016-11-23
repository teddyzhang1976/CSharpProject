using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericBindingList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            BindingList<Person> People = new BindingList<Person>();//创建泛型绑定列表
            for (int i = 0; i < 10; i++)//为泛型绑定列表添加元素
            {
                People.Add(new Person(i, "User0" + i.ToString()));
            }
            //过滤、排序泛型绑定列表
            var query = from p in People
                        where p.Name.Equals("User03")
                        orderby p.ID descending
                        select new
                        {
                            人员ID = p.ID,
                            人员名称 = p.Name
                        };
            foreach (var item in query)//显示查询结果
            {
                label1.Text += item + "\n";
            }
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
        public string Name { get; set; }//人员姓名
    }
}
