using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SearchElementByAttribute
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            LoadData("");
        }
        private void LoadData(string idcard)
        {
            string xmlFilePath = "Employee.xml";//xml文件存放的路径
            XElement xes = XElement.Load(xmlFilePath);//加载xml文件
            if (idcard == "")
            {
                //查询所有的元素
                var elements = from ee in xes.Elements("Person")
                               select new
                               {
                                   姓名 = ee.Element("Name").Value,
                                   性别 = ee.Element("Sex").Value,
                                   年龄 = ee.Element("Age").Value,
                                   身份证号 = ee.Attribute("IDCard").Value
                               };
                dataGridView1.DataSource = elements.ToList();
            }
            else
            {
                //查询指定名称的元素
                var elements = from ee in xes.Elements("Person")
                               where ee.Attribute("IDCard").Value == idcard
                               select new
                               {
                                   姓名 = ee.Element("Name").Value,
                                   性别 = ee.Element("Sex").Value,
                                   年龄 = ee.Element("Age").Value,
                                   身份证号 = ee.Attribute("IDCard").Value
                               };
                dataGridView1.DataSource = elements.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData(comboBox1.Text);
        }
    }
}
