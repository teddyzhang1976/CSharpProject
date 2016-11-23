using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReplaceAll
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string path = "new.xml";//取XML文件的全路径
            XElement xe = XElement.Load(path);//加载XML文件
            //用LINQ查找要修改的元素
            IEnumerable<XElement> element = from ee in xe.Elements("Person")
                                            where ee.Attribute("IDCard").Value == "22030219901111***"
                                            && ee.Element("Name").Value == "李四"
                                            select ee;
            if (element.Count() > 0)//存在要修改的元素
            {
                XElement first = element.First();//取第一个元素
                //全部替换成新的节点
                first.ReplaceAll(
                    new XAttribute("IDCard", "22030219891111XXX"),
                    new XElement("Name", "李丽"),
                    new XElement("Sex", "女"),
                    new XElement("Age", 21)
                    );
            }
            xe.Save(path);//保存文件
            webBrowser1.Url = new Uri(Application.StartupPath + "\\" + path);//在窗体中显示XML文件内容
        }
    }
}
