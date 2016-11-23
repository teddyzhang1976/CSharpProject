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

namespace AddXMLByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";//记录XML文件路径

        //窗体加载时加载XML文件
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(strPath))
            {
                getXmlInfo();
            }
        }

        //添加XML元素
        private void button2_Click(object sender, EventArgs e)
        {
            XElement xe = XElement.Load(strPath);//加载XML文档
            IEnumerable<XElement> elements1 = from element in xe.Elements("People")//创建IEnumerable泛型接口对象
                                              select element;
            //生成新的编号
            string str = (Convert.ToInt32(elements1.Max(element => element.Attribute("ID").Value)) + 1).ToString("000");
            XElement people = new XElement(//创建XML元素
                "People", new XAttribute("ID", str),//为XML元素设置属性
                new XElement("Name", textBox11.Text),
                new XElement("Sex", comboBox1.Text),
                new XElement("Salary", textBox12.Text)
                );
            xe.Add(people);//添加XML元素
            xe.Save(strPath);//保存XML元素到XML文件
            getXmlInfo();
        }

        #region 将XML文件内容绑定到DataGridView控件
        /// <summary>
        /// 将XML文件内容绑定到DataGridView控件
        /// </summary>
        private void getXmlInfo()
        {
            DataSet myds = new DataSet();//创建DataSet数据集对象
            myds.ReadXml(strPath);//读取XML结构
            dataGridView1.DataSource = myds.Tables[0];//在DataGridView中显示XML文件中的信息
        }
        #endregion
    }
}
