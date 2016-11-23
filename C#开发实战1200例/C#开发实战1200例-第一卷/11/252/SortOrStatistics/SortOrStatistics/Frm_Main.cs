using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SortOrStatistics
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getScoure("select * from [tb_ware]");
        }
        public void getScoure(string strName)
        {
            try
            {
                string P_Connection = string.Format(//创建数据库连接字符串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //创建连接对象
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//连接到数据库
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                    strName,
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到数据读取器
                    P_OLEDBCommand.ExecuteReader();
                listView1.View = View.Details;//设置控件显示方式
                listView1.GridLines = true;//显示网络线
                listView1.FullRowSelect = true;//被选中时是否连带选中子项
                listView1.Items.Clear();//清空元素
                while (P_Reader.Read())//读取数据
                {
                    ListViewItem lv = //创建项
                        new ListViewItem(P_Reader[0].ToString());
                    lv.SubItems.Add(P_Reader[1].ToString());//创建项
                    lv.SubItems.Add(P_Reader[2].ToString());//创建项
                    listView1.Items.Add(lv);//向ListView控件中添加项
                }
                P_OLEDBConnection.Close();//关闭连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//弹出消息对话框
                    "数据读取失败！\r\n" + ex.Message, "错误！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getScoure(//调用方法重新向控件添加数据
                "select * from [tb_ware]  order by [销售数量] asc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getScoure(//调用方法重新向控件添加数据
                "select * from [tb_ware] order by [销售数量] Desc");
        }
    }
}