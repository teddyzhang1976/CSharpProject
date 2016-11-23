using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GetConfiguration
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string strDatabase = string.Empty;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = Database();//设置数据源
            this.comboBox1.DisplayMember = "name";//设置显示属性
        }

        private DataTable Database()
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=WIN-GI7E47AND9R\LS;UID=sa;Pwd=hbyt2008!@#;database=master"))
            {
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器对象
                    "select name from sysdatabases ", con);
                DataTable dt = new DataTable("sysdatabases");//创建数据表
                da.Fill(dt);//填充数据表
                return dt;//返回数据表
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;//设置数据源
            strDatabase = this.comboBox1.Text.ToString();//得到数据库名称
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=WIN-GI7E47AND9R\LS;UID=sa;Pwd=hbyt2008!@#;database='" + strDatabase + "'"))
            {
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器
                    @"SELECT name FROM sysobjects 
WHERE type = 'U' and name<>'dtproperties' ", con);
                DataTable dt = new DataTable("sysobjects");//创建数据表
                da.Fill(dt);//填充数据表
                this.listBox1.DataSource = dt.DefaultView;//设置数据源
                this.listBox1.DisplayMember = "name";//设置显示值
                this.listBox1.ValueMember = "name";//设置实际值
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string strTableName = this.listBox1.SelectedValue.ToString();//获取数据表名称
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
 @"server=WIN-GI7E47AND9R\LS;UID=sa;Pwd=hbyt2008!@#;database='" + strDatabase + "'"))
            {
                string strSql =//创建SQL字符串
                    @"select  name 字段名, xusertype 类型编号, length 长度 into hy_Linshibiao 
from  syscolumns  where id=object_id('" + strTableName + "') ";
                strSql +=//添加字符串信息
@"select name 类型,xusertype 类型编号 into angel_Linshibiao from 
systypes where xusertype in (select xusertype 
from syscolumns where id=object_id('" + strTableName + "'))";
                con.Open();//打开数据库连接
                SqlCommand cmd = new SqlCommand(strSql, con);//创建命令对象
                cmd.ExecuteNonQuery();//执行SQL命令
                con.Close();//关闭数据库连接
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器
                    @"select 字段名,类型,长度 from 
hy_Linshibiao t,angel_Linshibiao b where t.类型编号=b.类型编号", con);
                DataTable dt = new DataTable();//创建数据表
                da.Fill(dt);//填充数据表
                this.dataGridView1.DataSource = dt.DefaultView;//设置数据源
                SqlCommand cmdnew = new SqlCommand(//创建命令对象
                    "drop table hy_Linshibiao,angel_Linshibiao", con);
                con.Open();//打开数据库连接
                cmdnew.ExecuteNonQuery();//执行SQL命令
                con.Close();//关闭数据库连接
            }
        }
    }
}
