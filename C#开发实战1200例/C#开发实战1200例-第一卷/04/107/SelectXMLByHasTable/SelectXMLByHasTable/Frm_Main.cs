using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace SelectXMLByHasTable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 在XML文件中查找电台地址及名称
        /// <summary>
        /// 在XML文件中查找电台地址及名称
        /// </summary>
        /// <param name="strPath">XML文件路径</param>
        /// <returns>Hashtable对象，用来记录找到的电台地址及名称</returns>
        static Hashtable SelectXML(string strPath)
        {
            Hashtable HTable = new Hashtable();//实例化哈希表对象
            XmlDocument doc = new XmlDocument();//实例化XML文档对象
            doc.Load(strPath);//加载XML文档
            XmlNodeList xnl = doc.SelectSingleNode("BCastInfo").ChildNodes;//获取NewDataSet节点的所有子节点
            string strVersion = "";//定义一个字符串，用来记录电台地址
            string strInfo = "";//定义一个字符串，用来记录电台名称
            foreach (XmlNode xn in xnl)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                if (xe.Name == "DInfo")//判断节点名为DInfo
                {
                    XmlNodeList xnlChild = xe.ChildNodes;//继续获取xe子节点的所有子节点
                    foreach (XmlNode xnChild in xnlChild)//遍历
                    {
                        XmlElement xeChild = (XmlElement)xnChild;//转换类型
                        if (xeChild.Name == "Address")
                        {
                            strVersion = xeChild.InnerText;//记录电台地址
                        }
                        if (xeChild.Name == "Name")
                        {
                            strInfo = xeChild.InnerText;//记录电台名称
                        }
                    }
                    HTable.Add(strVersion, strInfo);//向哈希表中添加键值
                }
            }
            return HTable;
        }
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Hashtable myHashtable = SelectXML("BroadCastInfo.xml");//使用自定义方法实例化哈希表对象
            IDictionaryEnumerator IDEnumerator = myHashtable.GetEnumerator();//循环访问哈希表
            while (IDEnumerator.MoveNext())
            {
                cbox_Name.Items.Add(IDEnumerator.Value.ToString());//显示电台名称
                cbox_NetAddress.Items.Add(IDEnumerator.Key.ToString());//显示电台网址
            }
            cbox_Name.SelectedIndex = cbox_NetAddress.SelectedIndex = 0;//设置默认选项
        }
    }
}
