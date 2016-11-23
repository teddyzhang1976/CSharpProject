using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsQueryable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<Person> People = new List<Person>//创建人员列表
        {
            new Person(1,"赵*东"),
            new Person(2,"王*科"),
            new Person(3,"王*军")
        };
            var query = from p in People.AsQueryable<Person>()//转换为IQueryable<Person>类型
                        where p.Name.IndexOf('王') > -1
                        select new
                        {
                            ID = p.ID,
                            Name = p.Name
                        };
            foreach (var item in query)//输出查询结果
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
