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

namespace XmlToDatabase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";//记录XML文件路径
        //定义数据库连接字符串
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        linqtosqlDataContext linq; //创建Linq连接对象

        //窗体加载时加载XML文件
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(strPath))
            {
                getXmlInfo();
            }
        }

        //将数据更新到数据库
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)//遍历所有行
            {
                linq = new linqtosqlDataContext(strCon);//创建linq连接对象
                tb_XML xml = new tb_XML();//创建tb_XML对象
                xml.ID = dataGridView1.Rows[i].Cells[3].Value.ToString();//为ID赋值
                xml.Name = dataGridView1.Rows[i].Cells[0].Value.ToString();//为Name赋值
                xml.Sex = dataGridView1.Rows[i].Cells[1].Value.ToString();//为Sex赋值
                xml.Salary = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);//为Salary赋值
                linq.tb_XML.InsertOnSubmit(xml);//提交数据
                linq.SubmitChanges();//执行对数据库的修改
                linq.Dispose();//释放linq对象
            }
            MessageBox.Show("成功将XML中的数据更新到了数据库中！");//弹出提示
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
