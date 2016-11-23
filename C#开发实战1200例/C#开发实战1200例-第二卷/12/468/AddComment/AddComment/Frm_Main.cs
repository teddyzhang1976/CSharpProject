using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AddComment
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string xmlFilePath = Application.StartupPath+"\\new.xml";//取XML文件的全路径
            XElement xe = XElement.Load(xmlFilePath);//加载XML文件
            //用LINQ查找要操作的元素
            IEnumerable<XElement> elements = from ee in xe.Elements("Person")
                                             where ee.Attribute("IDCard").Value == "22030219901111***"
                                             && ee.Element("Name").Value == "李四"
                                             select ee;
            if (elements.Count() > 0)//存在要操作的元素
            {
                XElement first = elements.First();//取第一个元素
                first.AddFirst(new XComment("身份证号必须唯一"));//添加注释
            }
            xe.Save(xmlFilePath);//保存XML文件
            webBrowser1.Url = new Uri(xmlFilePath);//在窗体中显示XML
        }
    }
}
