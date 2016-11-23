using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AttributeToElement
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
            IEnumerable<XElement> element = from ee in xe.Elements("Person")
                                            where ee.Attribute("IDCard").Value == "22030219901111***"
                                            && ee.Element("Name").Value == "李四"
                                            select ee;
            if (element.Count() > 0)						//存在要操作的元素
            {
                XElement first = element.First();
                XAttribute attribute = first.Attribute("IDCard");//取身份证号属性
                //添加一个名称和值都与属性一样的子元素
                first.AddFirst(
                    new XElement(attribute.Name, attribute.Value)
                    );
                first.RemoveAttributes();//删除身份证号属性
            }
            xe.Save(xmlFilePath);//保存XML文件
            webBrowser1.Url = new Uri(xmlFilePath);//在窗体中显示XML内容
        }
    }
}
