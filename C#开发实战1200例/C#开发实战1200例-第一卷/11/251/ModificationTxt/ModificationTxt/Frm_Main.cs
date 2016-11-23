using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;//声明与数据库有关的命名空间

namespace ModificationTxt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        OleDbDataAdapter WidgetAdapter;//声明一个数据读取器
        DataSet WidgetSet;//声明一个数据集
        OleDbConnection WidgetConnection;//声明一个数据库连接对象
        private string ConnectString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin";//定义一个数据库连接字符串
        
        

        private void listView1_AfterLabelEdit(object sender,LabelEditEventArgs e)
        {
            WidgetConnection = new OleDbConnection(ConnectString);//初始化一个数据库连接
            if(WidgetConnection.State == ConnectionState.Closed)//当数据库连接处于关闭状态时
            {
                WidgetConnection.Open();//打开数据库连接
            }
            if(e.Label != null && e.Label != "")//当选定项的文本内容存在且不为空时
            {
                string RefreshString = "update tb_WidgetApply set 产品名称='" //定义更新数据库字符串
                    + e.Label + "' where 产品编号=" + 
                    (e.Item+1).ToString();
                OleDbCommand WidgetCommand = new OleDbCommand(//声明一个执行SQL语句的对象
                    RefreshString,WidgetConnection);
                WidgetCommand.ExecuteNonQuery();//执行SQL语句
                WidgetConnection.Close();//关闭数据库连接
                MessageBox.Show("数据修改成功！","提示信息",//弹出信息提示
                    MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.Fill;//设置listView1与其父容器的停靠模式
            listView1.Columns.Add("产品名称", 100, HorizontalAlignment.Left);//向listView1控件中添加“产品名称”列
            listView1.Columns.Add("产品说明", 200, HorizontalAlignment.Center);//向listView1控件中添加“产品说明”列
            WidgetConnection = new OleDbConnection(ConnectString);//初始化一个数据库连接
            string SelectString = "select [产品名称],[产品说明] from [tb_WidgetApply]";//定义一个数据库查询字符串
            WidgetAdapter = new OleDbDataAdapter(SelectString, WidgetConnection);//初始化数据读取器对象
            WidgetSet = new DataSet();//初始化数据集
            WidgetAdapter.Fill(WidgetSet, "WidgetApply");//填充数据集
            for (int i = 0; i < WidgetSet.Tables["WidgetApply"].Rows.Count; i++)//循环遍历数据集中的每一行数据
            {
                listView1.Items.Add(WidgetSet.Tables["WidgetApply"].Rows[i][0].ToString()).
                    SubItems.Add(WidgetSet.Tables["WidgetApply"].
                    Rows[i][1].ToString());//向listView1控件中添加数据
            }
            listView1.LabelEdit = true;//设置listView1的可编辑属性为真
        }
    }
}
