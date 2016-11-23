using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BatchOperByTrans
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private SqlConnection m_Conn = null;//声明数据库连接对象
        private SqlCommand m_Cmd = null;//声明执行SQL命令对象

        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化数据库连接对象
            m_Conn = new SqlConnection("Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");
            m_Cmd = new SqlCommand();//实例化执行SQL命令对象
            BindDataGridView("");//对DataGridView控件进行数据绑定
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strPRProduceCode = null; //生产单号
            string strSql = null;//要执行的单条SQL语句
            List<string> strSqls = new List<string>();//SQL语句集合
            if (this.dgvPRProduceInfo.RowCount <= 0)//判断数据表格中是否有行
            {
                return;
            }
            strPRProduceCode = this.dgvPRProduceInfo["PRProduceCode", this.dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();//获取选中的生产单号
            //删除生产单子表
            strSql = "DELETE FROM PRProduceItem WHERE PRProduceCode = '" + strPRProduceCode + "'";
            strSqls.Add(strSql);//将要执行的SQL语句添加到List泛型集合中
            //删除生产单主表
            strSql = "DELETE FROM PRProduce WHERE PRProduceCode = '" + strPRProduceCode + "'";
            strSqls.Add(strSql);//将要执行的SQL语句添加到List泛型集合中
            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)//弹出删除确认对话框
            {
                try
                {
                    if (ExecDataBySqls(strSqls))//调用自定义方法批量删除数据
                    {
                        MessageBox.Show("删除成功！", "软件提示");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "软件提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                }
                BindDataGridView("");//重新对DataGridView控件进行数据绑定
            }
        }

        /// <summary>
        /// 通过Transact-SQL语句得到DataSet数据集
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <param name="strTable">相关的数据表</param>
        /// <returns>DataSet数据集</returns>
        public DataSet GetDataSet(string strSql, string strTable)
        {
            DataSet ds = null;//声明数据集对象
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(strSql, m_Conn);//实例化数据桥接器对象
                ds = new DataSet();//实例化数据集对象
                sda.Fill(ds, strTable);//填充DataSet数据集
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;//返回得到的DataSet数据集
        }

        /// <summary>
        /// DataGridView控件绑定数据源
        /// </summary>
        /// <param name="strWhere">Where条件子句</param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;//定义个字符串变量，用来存储SQL查询语句
            strSql = "SELECT * FROM PRProduce " + strWhere;//组合SQL查询语句
            try
            {
                //设置DataGridView控件的数据源
                dgvPRProduceInfo.DataSource = GetDataSet(strSql, "PRProduce").Tables["PRProduce"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        /// <summary>
        /// 多条Transact-SQL语句提交数据
        /// </summary>
        /// <param name="strSqls">使用List泛型封装多条SQL语句</param>
        /// <returns>bool值(提交是否成功)</returns>
        public bool ExecDataBySqls(List<string> strSqls)
        {
            bool booIsSucceed;//标识是否成功
            if (m_Conn.State == ConnectionState.Closed)//判断数据库连接状态是否关闭
            {
                m_Conn.Open();//打开数据库连接
            }
            SqlTransaction sqlTran = m_Conn.BeginTransaction();//实例化事务对象
            try
            {
                m_Cmd.Connection = m_Conn;//指定SqlCommand对象的连接对象
                m_Cmd.Transaction = sqlTran;//指定SqlCommand对象的事务对象
                foreach (string item in strSqls)//遍历List泛型集合中的所有SQL命令
                {
                    m_Cmd.CommandType = CommandType.Text;//指定SqlCommand对象的执行命令方式
                    m_Cmd.CommandText = item;//指定SqlCommand对象要执行的SQL命令
                    m_Cmd.ExecuteNonQuery();//执行SQL命令
                }
                sqlTran.Commit();//提交数据库
                booIsSucceed = true;//表示提交数据库成功
            }
            catch
            {
                sqlTran.Rollback();//事务回滚
                booIsSucceed = false;//表示提交数据库失败
            }
            finally
            {
                m_Conn.Close();//关闭数据库连接
                strSqls.Clear();//清空List泛型集合
            }
            return booIsSucceed;//返回结果，判断是否执行成功
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
