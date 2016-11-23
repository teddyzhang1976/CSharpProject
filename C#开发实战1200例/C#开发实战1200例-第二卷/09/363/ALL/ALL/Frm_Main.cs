using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALL
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
            new Person(1,"王*军",28),
            new Person(2,"赵*东",31),
            new Person(3,"王*科",33)
        };
            bool result = People.All(p => p.Old > 30);//判断是否所有人员的年龄都大于30岁
            //显示查询结果
            label1.Text = "数据源：{1,\"王*军\",28},{2,\"赵*东\",31},{3,\"王*科\",33}";//数据源
            label2.Text = "查询表达式：All(p => p.Old > 30)";//查询表达式/操作
            label3.Text = "查询结果：" + result.ToString();//查询结果
        }
    }
    public class Person
    {
        public Person(int id, string name, int old)
        {
            this.ID = id;
            this.Name = name;
            this.Old = old;
        }
        public int ID { get; set; }//人员ID
        public string Name { get; set; }//人员名称
        public int Old { get; set; }//年龄
    }
}
