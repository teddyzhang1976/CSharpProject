using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreStuInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        partial class CommInfo
        {
            /// <summary>
            /// 编号
            /// </summary>
            public object ID;
            /// <summary>
            /// 姓名
            /// </summary>
            public object Name;
            /// <summary>
            /// 性别
            /// </summary>
            object sex;
            public object Sex
            {
                get
                {
                    if ((bool)sex == true)
                        sex = "男";
                    else
                        sex = "女";
                    return sex;
                }
                set { sex = value; }
            }
            /// <summary>
            /// 年龄
            /// </summary>
            public object Age;
            /// <summary>
            /// 出生年月
            /// </summary>
            public object Birthday;
        }

        partial class CommInfo
        {
            /// <summary>
            /// 年级
            /// </summary>
            public object Grade;
            /// <summary>
            /// 班级
            /// </summary>
            public object Class;
            /// <summary>
            /// 班主任
            /// </summary>
            public object Director;
         }

        CommInfo Comminfo = new CommInfo();//实例化分部类对象
        private void Form1_Load(object sender, EventArgs e)
        {
            //为分部类中的各个属性赋值
            Comminfo.ID = "0001";
            Comminfo.Name = "刘同学";
            Comminfo.Sex = false;
            Comminfo.Age = 25;
            Comminfo.Birthday = Convert.ToDateTime("1985-04-25");
            Comminfo.Grade = 3;
            Comminfo.Class = 5;
            Comminfo.Director = "王老师";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //通过访问分部类中的属性显示学生信息
            textBox_ID.Text = Comminfo.ID.ToString();
            textBox_Name.Text = Comminfo.Name.ToString();
            textBox_Sex.Text = Comminfo.Sex.ToString();
            textBox_Age.Text = Comminfo.Age.ToString();
            textBox_Birthday.Text = Comminfo.Birthday.ToString();
            textBox_Grade.Text = Comminfo.Grade.ToString();
            textBox_Class.Text = Comminfo.Class.ToString();
            textBox_Director.Text = Comminfo.Director.ToString();
        }
    }
}
