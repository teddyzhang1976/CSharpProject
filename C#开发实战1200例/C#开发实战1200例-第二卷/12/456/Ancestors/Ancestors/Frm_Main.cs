using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ancestors
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
                        new XAttribute("IDCard", "22030219771012***"),
                        new XElement("Name", "张三"),
                        new XElement("Sex", "男"),
                        new XElement("Age", 34)
                        ),
                    new XElement("Person",
                        new XAttribute("IDCard", "22030219901111***"),
                        new XElement("Name", "李四"),
                        new XElement("Sex", "女"),
                        new XElement("Age", 20)
                        )
                    )
                );
            IEnumerable<XElement> elements = doc.Element("People").Descendants("Name");	//取所有的Name元素
            label1.Text="显示源元素\n";
            foreach (XElement element in elements)//遍历输出Name元素
            {
                label1.Text += "元素名称：" + element.Name + "   元素值：" + element.Value + "\n";
            }
            label1.Text += "显示每个源元素的祖先元素\n";
            foreach (XElement element in elements.Ancestors())//遍历输出每个Name元素的所有上级节点
            {
                label1.Text += "元素名称：" + element.Name + "   元素值：" + element.Value + "\n";
            }
        }
    }
}
