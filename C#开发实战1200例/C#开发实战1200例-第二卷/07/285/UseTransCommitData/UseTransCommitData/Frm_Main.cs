using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseTransCommitData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //创建数据库连接对象
            SqlConnection sqlConn = new SqlConnection("Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;uid=sa;pwd =;");
            List<String> strSqls = new List<string>();//创建集合对象
            String strDelete1 = "delete From tb_Author Where AuthorId = '99'";//定义删除第一个表的SQL语句
            strSqls.Add(strDelete1);//将SQL语句添加到集合中
            String strDelete2 = "delete From tb_AuthorsBook Where AuthorId = '99'";//定义删除第二个表的SQL语句
            strSqls.Add(strDelete2);//将SQL语句添加到集合中
            string strInsert1 = "insert into tb_Author values('99','zhd')";//定义添加第一个表的SQL语句
            strSqls.Add(strInsert1);//将SQL语句添加到集合中
            string strInsert2 = "insert into tb_AuthorsBook values('66','C#范例大全','99')";//定义添加第二个表的SQL语句
            strSqls.Add(strInsert2);//将SQL语句添加到集合中
            if (ExecDataBySqls(strSqls, sqlConn))//如果执行成功
            {
                MessageBox.Show("提交tb_Author数据表成功！", "信息提示");
                MessageBox.Show("提交tb_AuthorsBook数据表成功！","信息提示");
            }
            else
            {
                MessageBox.Show("提交tb_Author数据表失败！", "信息提示");
                MessageBox.Show("提交tb_AuthorsBook数据表失败！", "信息提示");
            }
            SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from tb_Author", sqlConn);//创建数据桥接器对象
            SqlDataAdapter sqlda2 = new SqlDataAdapter("select * from tb_AuthorsBook", sqlConn);//创建数据桥接器对象
            DataSet myds = new DataSet();//创建数据集对象
            sqlda1.Fill(myds, "tb_Author");//填充数据集
            sqlda2.Fill(myds, "tb_AuthorsBook");//填充数据集
            dataGridView1.DataSource = myds.Tables["tb_Author"];//对第一个DataGridView进行数据绑定
            dataGridView2.DataSource = myds.Tables["tb_AuthorsBook"];//对第二个DataGridView进行数据绑定
        }

        /// <param name="strSqls">使用List泛型封装多条SQL语句</param>
        /// <param name="sqlConn">数据库连接</param>
        public bool ExecDataBySqls(List<string> strSqls, SqlConnection sqlConn)
        {
            bool booIsSucceed = false;//声明提交数据是否成功的标记
            SqlCommand sqlCmd = new SqlCommand();//创建SqlCommand对象
            sqlCmd.Connection = sqlConn;//设置SqlCommand对象的Connection属性
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();//打开数据库连接
            }
            SqlTransaction sqlTran = sqlConn.BeginTransaction();//开始一个事务
            try
            {
                sqlCmd.Transaction = sqlTran;//设置SqlCommand对象的Transaction属性
                foreach (string item in strSqls)
                {
                    sqlCmd.CommandType = CommandType.Text;//设置命令类型为SQL文本命令
                    sqlCmd.CommandText = item;//设置要对数据源执行的SQL语句
                    sqlCmd.ExecuteNonQuery();//执行SQL语句并返回受影响的行数
                }
                sqlTran.Commit();//提交事务，持久化数据
                booIsSucceed = true;//表示提交数据库成功
            }
            catch
            {
                sqlTran.Rollback();//回滚事务，恢复数据
                booIsSucceed = false;//表示提交数据库失败！
            }
            finally
            {
                sqlConn.Close();//关闭连接
                strSqls.Clear();//清除列表strSqls中的元素
            }
            return booIsSucceed;//方法返回值
        }
    }
}
