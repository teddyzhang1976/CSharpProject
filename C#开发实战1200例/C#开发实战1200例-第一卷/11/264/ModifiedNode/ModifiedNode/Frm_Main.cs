using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;//声明与数据库操作有关的命名空间

namespace ModifiedNode
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        OleDbCommand NexusCommand;//声明一个执行SQL语句的对象
        OleDbConnection NexusConnection;//声明一个数据库连接对象
        private static string ConnectString = 
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin";//定义一个数据库连接字符串

        private void ModifiedNode_Load(object sender,EventArgs e)
        {
            treeView1.LabelEdit = true;//设置treeView1的可编辑属性为true
            NexusConnection = new OleDbConnection(ConnectString);//初始化一个数据库连接对象
            NexusConnection.Open();//打开数据库连接
            string SelectString = "select 产品编号,产品名称 from Ware";//定义一个数据库查询字符串
            NexusCommand = new OleDbCommand(SelectString,NexusConnection);//初始化执行SQL语句对象
            OleDbDataReader NexusReader = NexusCommand.ExecuteReader();//定义一个数据读取器
            treeView1.Nodes.Clear();//清空treeView1原有的数据内容
            TreeNode root = treeView1.Nodes.Add("产品名称");//为treeView1控件添加根节点
            while(NexusReader.Read())//开始读取数据中的内容
            {
                TreeNode tempNode = //将数据库中的数据字段变换为treeView控件的节点
                    new TreeNode(NexusReader[1].ToString());
                root.Nodes.Add(tempNode);//向根节点上添加数据库字段
            }
            NexusReader.Close();//关闭数据读取器
            root.ExpandAll();//展开treeView1中的所有节点
            NexusConnection.Close();//关闭数据库连接
        }

        private void treeView1_AfterLabelEdit(object sender,NodeLabelEditEventArgs e)
        {
            if(e.Label != null && e.Label != "")//当选定项的内容存在且不为空时
            {
                NexusConnection.Open();//打开数据库连接
                string RefreshString = "update Ware set 产品名称='" + //定义一个数据库连接字段
                    e.Label + "' where 产品编号=" + (e.Node.Index + 1).ToString();
                NexusCommand = new OleDbCommand(RefreshString,NexusConnection);//定义一个执行SQL语句的对象
                NexusCommand.ExecuteNonQuery();//执行SQL语句
                NexusConnection.Close();//关闭数据库连接
                MessageBox.Show("修改成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);//弹出修改成功的提示信息
            }
        }
    }
}
