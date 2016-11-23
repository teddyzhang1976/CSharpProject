using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Transactions;

namespace HideTransaction
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strConn = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;uid=sa;pwd =;";//设置数据连接字符串
            SqlConnection sqlConn = new SqlConnection(strConn);//创建数据连接
            SqlCommand sqlCmd = new SqlCommand();//创建命令执行对象
            sqlCmd.Connection = sqlConn;//设置命令对象的连接
            sqlConn.Open();//打开数据连接
            List<string> strSqls = new List<string>();//创建字符串列表
            String strDelete1 = "Delete From tb_AuthorsBook Where AuthorId = '99'";//声明SQL语句字符串
            strSqls.Add(strDelete1);//向字符串列表添加字符串
            String strDelete2 = "Delete From tb_Author Where AuthorId = '99'";
            strSqls.Add(strDelete2);
            String strInsert1 = "insert into tb_Author values('99','zhd')";
            strSqls.Add(strInsert1);
            String strInsert2 = "insert into tb_AuthorsBook values('66','C#范例大全','99')";
            strSqls.Add(strInsert2);
            try
            {
                using (TransactionScope txScope = new TransactionScope())//创建事务范围对象
                {
                    foreach (String strSql in strSqls)//向多个表提交数据
                    {
                        sqlCmd.CommandText = strSql;
                        sqlCmd.ExecuteNonQuery();//执行SQL语句
                    }
                }
                sqlConn.Close();//关闭连接
                MessageBox.Show("提交tb_Author表成功！", "信息提示");
                MessageBox.Show("提交tb_AuthorsBook表成功！", "信息提示");
            }
            catch
            {
                MessageBox.Show("提交tb_Author表失败！", "信息提示");
                MessageBox.Show("提交tb_AuthorsBook表失败！", "信息提示");
            }
            SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from tb_Author", sqlConn);//创建数据桥接器对象
            SqlDataAdapter sqlda2 = new SqlDataAdapter("select * from tb_AuthorsBook", sqlConn);//创建数据桥接器对象
            DataSet myds = new DataSet();//创建数据集对象
            sqlda1.Fill(myds, "tb_Author");//填充数据集
            sqlda2.Fill(myds, "tb_AuthorsBook");//填充数据集
            dataGridView1.DataSource = myds.Tables["tb_Author"];//对第一个DataGridView进行数据绑定
            dataGridView2.DataSource = myds.Tables["tb_AuthorsBook"];//对第二个DataGridView进行数据绑定
        }
    }
}
