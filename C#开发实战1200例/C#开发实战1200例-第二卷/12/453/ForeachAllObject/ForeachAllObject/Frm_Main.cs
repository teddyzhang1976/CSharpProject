using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ForeachAllObject
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
                        new XComment("身份证号是唯一的"),
                        new XElement("Name", "张三"),
                        new XElement("Sex", "男"),
                        new XElement("Old", 20),
                        new XText("这是文本对象")
                        )
                    )
                );
            IEnumerable<XNode> nods = doc.Element("People").Elements("Person").Nodes();//取Person节点下的所有对象
            foreach (XNode nod in nods)//遍历查找到的对象
            {
                string s = nod.ToString();//获取对象
                label1.Text += s + "\n";//将对象显示到窗体中
            }
        }
    }
}
