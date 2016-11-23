using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SumSalary
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

        //公司每月总薪水
        private void button4_Click(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(strCon);//创建数据库连接对象
            sqlda = new SqlDataAdapter("select * from tb_Salary", sqlcon);//创建数据库桥接器对象
            myds = new DataSet();//创建数据集对象
            sqlda.Fill(myds, "tb_Salary");//填充DataSet数据集
            var query = from salary in myds.Tables["tb_Salary"].AsEnumerable()//查询DataSet数据集中所有薪水
                        where salary.Field<int>("Salary") > 0
                        select salary;
            int intSum = query.Sum(salary => salary.Field<int>("Salary"));//汇总薪水
            DataTable myDTable = new DataTable();//创建DataTable对象
            myDTable.Columns.Add("公司每月总薪水");//在数据表中添加列
            DataRow myDRow = myDTable.NewRow();//创建DataRow对象
            myDRow["公司每月总薪水"] = intSum;//为DataRow中的行赋值
            myDTable.Rows.Add(myDRow);//将DataRow添加到DataTable的行集合中
            dataGridView1.DataSource = myDTable;//显示查询到的数据集中的信息
            dataGridView1.Columns[0].Width = 120;//设置DataGridView控件的列宽
        }

        //刷新
        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
