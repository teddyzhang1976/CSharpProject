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

namespace DelXMLByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";//记录XML文件路径
        static string strID = "";//记录选中的ID编号

        //窗体加载时加载XML文件
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(strPath))
            {
                getXmlInfo();
            }
        }

        //删除XML元素
        private void button4_Click(object sender, EventArgs e)
        {
            if (strID != "")//判断是否选择了编号
            {
                XElement xe = XElement.Load(strPath);//加载XML文档
                IEnumerable<XElement> elements = from element in xe.Elements("People")//根据编号查找信息
                                                 where element.Attribute("ID").Value == strID
                                                 select element;
                if (elements.Count() > 0)//判断是否找到了信息
                    elements.First().Remove();//删除找到的XML元素信息
                xe.Save(strPath);//保存XML元素到XML文件
            }
            MessageBox.Show("删除成功");
            getXmlInfo();
        }

        //显示选中XML节点的详细信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();//记录选中的ID编号
            XElement xe = XElement.Load(strPath);//加载XML文档
            IEnumerable<XElement> elements = from PInfo in xe.Elements("People")//根据编号查找信息
                                             where PInfo.Attribute("ID").Value == strID
                                             select PInfo;
            foreach (XElement element in elements)//遍历查找到的所有信息
            {
                textBox11.Text = element.Element("Name").Value;//显示员工姓名
                comboBox1.SelectedItem = element.Element("Sex").Value;//显示员工性别
                textBox12.Text = element.Element("Salary").Value;//显示员工薪水
            }
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
