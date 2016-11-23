using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreIDAndName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string id = "";//定义一个string类型的变量，用来记录用户编号
        private string name = "";//定义一个string类型的变量，用来记录用户姓名
        /// <summary>
        ///定义用户编号属性，该属性为可读可写属性
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        ///定义用户姓名属性，该属性为可读可写属性
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ID = "BH001";//为用户编号属性赋值
            Name = "MR1";//为用户姓名属性赋值
            lab_First.Text = ID + "         " + Name;//显示用户编号和用户姓名
            ID = "BH002";//重新为用户编号属性赋值
            Name = "MR2";//重新为用户姓名属性赋值
            lab_Second.Text = ID + "         " + Name;//显示用户编号和用户姓名
        }
    }
}
