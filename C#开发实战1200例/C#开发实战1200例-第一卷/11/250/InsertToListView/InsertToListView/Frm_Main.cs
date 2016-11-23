using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace InsertToListView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string P_Connection = string.Format(//创建数据库连接字符串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //创建连接对象
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//连接到数据库
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                    "select * from [book]",
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到数据读取器
                    P_OLEDBCommand.ExecuteReader();
                while (P_Reader.Read())//读取数据
                {
                    ListViewItem lv = new ListViewItem(P_Reader[0].ToString());
                    lv.SubItems.Add(P_Reader[1].ToString());
                    lv.SubItems.Add(P_Reader[2].ToString());
                    listView1.Items.Add(lv);
                }
                P_OLEDBConnection.Close();//关闭数据库连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//弹出消息对话框
                    "数据读取失败！\r\n" + ex.Message, "错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();//清空数据
        }
    }
}