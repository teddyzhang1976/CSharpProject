using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SearchElementByName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string xmlFilePath = "Employee.xml";//xml文件存放的路径
            XElement xes = XElement.Load(xmlFilePath);//加载xml文件
            //查询指定名称的元素
            IEnumerable<XElement> elements = from ee in xes.Elements("People")
                                             where ee.Element("Name").Value == "小科"
                                             select ee;
            label1.Text = "查找指定名称的元素：\n";
            foreach (XElement xe in elements)//将查询到的元素输出
            {
                label1.Text += xe.Name.LocalName + "：" + xe.Attribute("ID").Value + "\n";
            }
        }
    }
}
