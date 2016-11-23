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

namespace OperateXML
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";
        static string strID = "";

        //窗体加载时加载XML文件
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(strPath))
            {
                groupBox1.Enabled = false;
                getXmlInfo();
            }
            else
                groupBox1.Enabled = true;
        }

        //创建XML文件
        private void button1_Click(object sender, EventArgs e)
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(textBox1.Text,
                    new XElement(textBox2.Text, new XAttribute(textBox3.Text, textBox10.Text),
                        new XElement(textBox4.Text, textBox5.Text),
                        new XElement(textBox6.Text, textBox7.Text),
                        new XElement(textBox8.Text, textBox9.Text))
                    )
                );
            doc.Save(strPath);
            groupBox1.Enabled = false;
            getXmlInfo();
        }

        //添加XML元素
        private void button2_Click(object sender, EventArgs e)
        {
            XElement xe = XElement.Load(strPath);
            IEnumerable<XElement> elements1 = from element in xe.Elements("People")
                                              select element;
            //生成新的编号
            string str = (Convert.ToInt32(elements1.Max(element => element.Attribute("ID").Value)) + 1).ToString("000");
            XElement people = new XElement(
                "People", new XAttribute("ID", str),
                new XElement("Name", textBox11.Text),
                new XElement("Sex", comboBox1.Text),
                new XElement("Salary", textBox12.Text)
                );
            xe.Add(people);
            xe.Save(strPath);
            getXmlInfo();
        }

        //修改XML元素
        private void button3_Click(object sender, EventArgs e)
        {
            if (strID != "")
            {
                XElement xe = XElement.Load(strPath);
                IEnumerable<XElement> elements = from element in xe.Elements("People")
                                                 where element.Attribute("ID").Value == strID
                                                 select element;
                if (elements.Count() > 0)
                {
                    XElement newXE = elements.First();
                    newXE.SetAttributeValue("ID", strID);
                    newXE.ReplaceNodes(
                        new XElement("Name", textBox11.Text),
                        new XElement("Sex", comboBox1.Text),
                        new XElement("Salary", textBox12.Text)
                        );
                }
                xe.Save(strPath);
            } 
            getXmlInfo();
        }

        //删除XML元素
        private void button4_Click(object sender, EventArgs e)
        {
            if (strID != "")
            {
                XElement xe = XElement.Load(strPath);
                IEnumerable<XElement> elements = from element in xe.Elements("People")
                                                 where element.Attribute("ID").Value == strID
                                                 select element;
                if (elements.Count() > 0)
                    elements.First().Remove();
                xe.Save(strPath);
            }
            getXmlInfo();
        }

        //显示选中XML节点的详细信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            XElement xe = XElement.Load(strPath);
            IEnumerable<XElement> elements = from PInfo in xe.Elements("People")
                                             where PInfo.Attribute("ID").Value == strID
                                             select PInfo;
            foreach (XElement element in elements)
            {
                textBox11.Text = element.Element("Name").Value;
                comboBox1.SelectedItem = element.Element("Sex").Value;
                textBox12.Text = element.Element("Salary").Value;
            }
        }

        #region 将XML文件内容绑定到DataGridView控件
        /// <summary>
        /// 将XML文件内容绑定到DataGridView控件
        /// </summary>
        private void getXmlInfo()
        {
            DataSet myds = new DataSet();
            myds.ReadXml(strPath);
            dataGridView1.DataSource = myds.Tables[0];
        }
        #endregion
    }
}
