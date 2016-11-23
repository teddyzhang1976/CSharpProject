using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FindTopFive
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";//定义数据库连接字符串
        SqlConnection sqlcon;//声明SqlConnection对象
        SqlDataAdapter sqlda;//声明SqlDataAdapter对象
        DataSet myds;//声明DataSet数据集对象
        #endregion

        //窗体加载时显示所有数据
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(strCon);//创建数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_Salary", sqlcon);//创建数据库桥接器对象
            myds = new DataSet();//创建数据集对象
            sqlda.Fill(myds, "tb_Salary");//填充DataSet数据集
            var query = from salary in myds.Tables["tb_Salary"].AsEnumerable()//使用LINQ从数据集中查询所有数据
                        select salary;
            DataTable myDTable = query.CopyToDataTable<DataRow>();//将查询结果转化为DataTable对象
            dataGridView1.DataSource = myDTable;//显示查询到的数据集中的信息
        }

        //前5名薪水
        private void button3_Click(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(strCon);//创建数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_Salary", sqlcon);//创建数据库桥接器对象
            myds = new DataSet();//创建数据集对象
            sqlda.Fill(myds, "tb_Salary");//填充DataSet数据集
            var query = from salary in myds.Tables["tb_Salary"].AsEnumerable()//查询DataSet数据集中所有信息
                        orderby salary.Field<int>("Salary") descending
                        select salary;
            var result = query.Take(5);//获取前5条记录
            DataTable myDTable = result.CopyToDataTable<DataRow>();//将查询结果转化为DataTable对象
            dataGridView1.DataSource = myDTable;//显示查询到的数据集中的信息
        }

        //刷新
        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
