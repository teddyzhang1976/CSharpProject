using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace DataBaseToTreeView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.ShowLines = true;//设置绘制连线
            treeView1.ImageList = imageList1;//设置ImageList属性
            string P_Connection = string.Format(//创建数据库连接字符串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //创建连接对象
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//连接到数据库
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                "select * from [Ware]",
                P_OLEDBConnection);
            OleDbDataReader P_Reader = //得到数据读取器
                P_OLEDBCommand.ExecuteReader();
            TreeNode newNode1 = treeView1.Nodes.Add("A","商品信息",1,2);//一级节点
            while (P_Reader.Read())
            {
                TreeNode newNode12 = new TreeNode(//二级节点
                    "商品编号" + P_Reader[1].ToString(), 3, 4);
                newNode12.Nodes.Add("A", "商品名称：" + P_Reader[0].ToString(), 5, 6);
                newNode12.Nodes.Add("A", "商品数量：" + P_Reader[3].ToString(), 7, 8);
                newNode12.Nodes.Add("A", "商品价格：" + P_Reader[2].ToString(), 9, 10);
                newNode1.Nodes.Add(newNode12);//添加节点
           
            }
            P_OLEDBConnection.Close();//关闭数据库连接
            treeView1.ExpandAll();//展开所有节点
        }
    }
}