using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace GenericCollection
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Collection<Person> People = new Collection<Person>{//创建泛型通用集合
            new Person(1,"王小*"),
            new Person(1,"赵会*"),
            new Person(1,"王小*")};
            var query = from p in People
                        where p.Name.IndexOf("小") > 0//过滤人员名称中包含"小"的序列
                        select new
                        {
                            人员ID = p.ID,
                            人员名称 = p.Name
                        };
            foreach (var item in query)//显示结果
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
