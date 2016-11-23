using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Attributes
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //使用LINQ创建XML
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("People",
                    new XElement("Person",
                        new XAttribute("Name", "张三"),
                        new XAttribute("Sex", "男"),
                        new XAttribute("Age", 34),
                        new XElement("IDCard", "22030219771012***")
                        ),
                    new XElement("Person",
                        new XAttribute("Name", "李四"),
                        new XAttribute("Sex", "女"),
                        new XAttribute("Age", 20),
                        new XElement("IDCard", "22030219901111***")
                        )
                    )
                );
            IEnumerable<XElement> elements = doc.Element("People").Elements("Person");//查询Person元素
            label1.Text="显示源元素\n";
            foreach (XElement element in elements)//遍历输出Person元素
            {
                label1.Text += "元素名称：" + element.Name + "   元素值：" + element.Value + "\n";
            }
            label1.Text += "显示每个源元素的属性\n";
            foreach (XAttribute attr in elements.Attributes())//遍历每个源元素的属性
            {
                label1.Text += "属性名称：" + attr.Name + "   属性值：" + attr.Value + "\n";
            }
        }
    }
}
