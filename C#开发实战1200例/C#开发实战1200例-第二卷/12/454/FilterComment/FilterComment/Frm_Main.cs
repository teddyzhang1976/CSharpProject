using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FilterComment
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
                        new XComment("身份证号必须唯一"),
                        new XElement("Name", "张三"),
                        new XElement("Sex", "男"),
                        new XElement("Age", 20),
                        new XComment("年龄不得超过120岁")
                        )
                    )
                );
            IEnumerable<XComment> cmts = doc.Element("People").Elements("Person").Nodes().OfType<XComment>();//取Person节点下的所有注释
            foreach (XComment cmt in cmts)//遍历查找到的注释
            {
                string s = cmt.ToString();//将注释HTML编码
                label1.Text += s + "\n";//将注释显示到窗体中
            }
        }
    }
}
