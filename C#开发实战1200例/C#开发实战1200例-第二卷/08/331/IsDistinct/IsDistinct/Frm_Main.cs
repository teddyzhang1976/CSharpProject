using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IsDistinct
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //连接数据库的字符串
        string connstr = @"Provider=SQLOLEDB;Data Source=LVSHUANG\SHJ; 
Integrated Security = SSPI;Persist Security Info=False;Initial Catalog=db_TomeTwo";

        public int isHomologyNote(string Table, string term1, string term2, string Value1, string Value2)
        {
            string tem_sql = "";//定义字符串变量
            System.Data.OleDb.OleDbConnection tem_conn =
                new System.Data.OleDb.OleDbConnection(connstr);//连接数据库
            System.Data.OleDb.OleDbCommand tem_comm;//定义OleDbCommand类
            tem_conn.Open();//打开数据库的连接
            //设置SQL语句，查找要添加的记录
            tem_sql = "select top 1 * From " + Table + " where " + term1 + " = '" + 
                Value1 + "' and " + term2 + " = '" + Value2 + "'";
            tem_comm = new System.Data.OleDb.OleDbCommand(tem_sql, tem_conn);//执行SQL语句
            int RecordCount = 0;//定义变量
            if (tem_comm.ExecuteScalar() == null)//如果查询为空
                RecordCount = 0;
            else
                RecordCount = (int)tem_comm.ExecuteScalar();//返回查找结果的个数
            tem_conn.Close();//关闭连接
            tem_comm.Dispose();//释放资源
            tem_conn.Dispose();//释放资源
            return RecordCount;//返回查询记录数量
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isHomologyNote("tb_BasicTable", "Number", "Name", textBox1.Text, textBox2.Text) > 0)//如果查询结果大于0
                MessageBox.Show("已有重复记录");//弹出提示框
            else//可以对该记录进行添加
                MessageBox.Show("无记录，可以添加");
        }
    }
}
