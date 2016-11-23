using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string M_str_Con = "Data Source=mrwxk\\wangxiaoke;Database=db_TomeOne;UID=sa;Pwd=hbyt2008!@#;";//定义数据库连接字符串
        SqlConnection sqlcon;//声明数据库连接对象
        SqlCommand sqlcmd;//声明执行命令对象
        SqlDataAdapter sqlda;//声明数据桥接器对象
        DataSet myds;//声明数据集对象
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_Condition.SelectedIndex = 0;//默认选择条件为第一项
            dgv_Info.DataSource = SelectEInfo("", "").Tables[0];//将数据库中的数据全部显示在数据表格控件中
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dgv_Info.DataSource = SelectEInfo(cbox_Condition.Text, txt_KeyWord.Text).Tables[0];//按条件查询数据
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgv_Info.Rows.Count == 0)//判断是否有数据
                return;//返回
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            excel.Application.Workbooks.Add(true);//在Excel中添加一个工作簿
            excel.Visible = true;//设置Excel显示
            //生成字段名称
            for (int i = 0; i < dgv_Info.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv_Info.Columns[i].HeaderText;//将数据表格控件中的列表头填充到Excel中
            }
            //填充数据
            for (int i = 0; i < dgv_Info.RowCount - 1; i++)//遍历数据表格控件的所有行
            {
                for (int j = 0; j < dgv_Info.ColumnCount; j++)//遍历数据表格控件的所有列
                {
                    if (dgv_Info[j, i].ValueType == typeof(string))//判断遍历到的数据是否是字符串类型
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dgv_Info[j, i].Value.ToString();//填充Excel表格
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = dgv_Info[j, i].Value.ToString();//填充Excel表格
                    }
                }
            }
        }

        #region 获得数据库连接
        /// <summary>
        /// 获得数据库连接
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        private SqlConnection getCon()
        {
            sqlcon = new SqlConnection(M_str_Con);//实例化数据库连接对象
            sqlcon.Open();//打开数据库连接
            return sqlcon;//返回数据库连接对象
        }
        #endregion

        #region 查询信息
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="str">查询条件</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataSet数据集对象</returns>
        private DataSet SelectEInfo(string P_str_Condition, string P_str_KeyWord)
        {
            sqlcon = getCon();//打开数据库连接
            sqlda = new SqlDataAdapter();//实例化数据桥接器对象
            sqlcmd = new SqlCommand("proc_SelectEInfo", sqlcon);//调用存储过程
            sqlcmd.CommandType = CommandType.StoredProcedure;//指定要执行的命令为存储过程
            switch (P_str_Condition)//以查询条件为条件
            {
                case "职工编号":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = P_str_KeyWord;//为存储过程添加ID参数
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";//为存储过程添加Name参数
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";//为存储过程添加Sex参数
                    break;
                case "职工姓名":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = P_str_KeyWord;
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
                case "性别":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = P_str_KeyWord;
                    break;
                default:
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
            }
            sqlda.SelectCommand = sqlcmd;//指定要执行的SelectCommand命令
            myds = new DataSet();//实例化数据集对象
            sqlda.Fill(myds);//填充DataSet数据集
            sqlcon.Close();//关闭数据库连接
            return myds;//返回数据集
        }
        #endregion
    }
}
