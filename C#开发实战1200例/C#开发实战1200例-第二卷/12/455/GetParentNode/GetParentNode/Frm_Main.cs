using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GetParentNode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //使用LINQ创建xml文件的内容
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
            XElement eleName = doc.Descendants("Name").Where(itm => itm.Value == "张三").First();//查找值等于"张三"的<Name>元素
            XElement xe = eleName.Parent;//获取父节点
            label1.Text=xe.ToString();//将父节点的内容输出
        }
    }
}
