using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqToXmlConvert
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//创建LINQ to SQL数据上下文类的对象
            string xmlFilePath = Application.StartupPath + "\\new.xml";//取出xml文件的全路径
            //使用LINQ to XML创建XML
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("People",
                    from p in dc.tb_Employee//根据LINQ to SQL取出的数据生成XML
                    select new XElement[]{
                new XElement("Person",
                new XAttribute("ID",p.ID),
                new XElement("Name",p.Name),
                new XElement("Sex",p.Sex),
                new XElement("Age", p.Age),
                new XElement("Tel",p.Tel),
                new XElement("QQ",p.QQ),
                new XElement("Email", p.Email),
                new XElement("Address", p.Address)
                )}
                    )
                );
            doc.Save(xmlFilePath);//保存XML文件
            webBrowser1.Url = new Uri(xmlFilePath);//在窗体中呈现XML文件的内容
        }
    }
}
