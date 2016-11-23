using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<Person> People = new List<Person>{//创建人员列表
            new Person(1,"王*科"),
            new Person(2,"王*科"),
            new Person(3,"赵*东")};
            var query = from p in People//过滤人员名称中以"科"结束的序列
                        where p.Name.EndsWith("科")
                        select new
                        {
                            人员ID = p.ID,
                            人员姓名 = p.Name
                        };
            foreach (var item in query)//遍历查询结果
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
