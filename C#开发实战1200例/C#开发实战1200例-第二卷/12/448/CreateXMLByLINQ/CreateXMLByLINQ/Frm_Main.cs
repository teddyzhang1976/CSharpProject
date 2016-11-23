using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace CreateXMLByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";

        //创建XML文件
        private void button1_Click(object sender, EventArgs e)
        {
            XDocument doc = new XDocument(//创建XML文档对象
                new XDeclaration("1.0", "utf-8", "yes"),//添加XML文件声明
                new XElement(textBox1.Text,//创建XML元素
                    new XElement(textBox2.Text, new XAttribute(textBox3.Text, textBox10.Text),//为XML元素添加属性
                        new XElement(textBox4.Text, textBox5.Text),
                        new XElement(textBox6.Text, textBox7.Text),
                        new XElement(textBox8.Text, textBox9.Text))
                    )
                );
            doc.Save(strPath);//保存XML文档
            MessageBox.Show("XML文件创建成功");
        }
    }
}
