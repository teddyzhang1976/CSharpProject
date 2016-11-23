using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace DrawBackGround
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string P_Connection = string.Format(//创建数据库连接字符串
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
                OleDbConnection P_OLEDBConnection = //创建连接对象
                    new OleDbConnection(P_Connection);
                P_OLEDBConnection.Open();//连接到数据库
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                    "select * from [message]",
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到数据读取器
                    P_OLEDBCommand.ExecuteReader();
                listView1.BackgroundImageTiled = true;//设置平铺背景图像
                listView1.View = View.LargeIcon;//设置控件的显示方式
                listView1.LargeImageList = imageList1;
                while (P_Reader.Read())//读取数据
                {
                    ListViewItem lv = //创建项
                        new ListViewItem(P_Reader[0].ToString(), 0);
                    listView1.Items.Add(lv);//向控件中添加项
                }
                P_OLEDBConnection.Close();//关闭数据库连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(//弹出消息对话框
                    "数据读取失败！\r\n" + ex.Message, "错误！");
            }
        }
    }
}