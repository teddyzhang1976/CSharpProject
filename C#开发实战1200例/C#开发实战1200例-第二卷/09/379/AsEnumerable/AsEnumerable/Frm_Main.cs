using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsEnumerable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<Person> People = new List<Person>();//创建List泛型对象
            for (int i = 1; i < 10; i++)
            {
                People.Add(new Person(i, "User0" + i.ToString()));//添加项
            }
            var query = from p in People.AsEnumerable<Person>()//转换为IEnumerable<Person>类型
                        where p.ID < 4
                        select new
                        {
                            ID = p.ID,
                            Name = p.Name
                        };
            foreach (var item in query)
            {
                label1.Text += item + "\n";//显示信息
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
        public string Name { get; set; }//人员名称
    }
}
