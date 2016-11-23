using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AddDocumentType
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string xmlFilePath = Application.StartupPath+"\\new.xml";//取出xml文件的全路径
            XDocument doc = new XDocument(
                new XDocumentType("People", null, "People.dtd", null),//添加文档类型
                new XElement("People", "员工信息")//添加根元素
                );
            doc.Save(xmlFilePath);//保存XML文件
            webBrowser1.Url = new Uri(xmlFilePath);//在窗体中显示XML文件
        }
    }
}
