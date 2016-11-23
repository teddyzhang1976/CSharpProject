using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FirstAndLast
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_Select.SelectedIndex = 0;//设置选择项
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetFirstStudent(//设置数据源
                cbox_Select.Text);
            dgv_Message.Columns[2].Width = 220;//设置列宽度
        }

        /// <summary>
        /// 查询销售排行
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetFirstStudent(string Select)
        {
            string strSql = "";//创建空字符串
            if (Select == "第一名")
            {
                strSql = @"SELECT FIRST(BookNames)AS Bookname,FIRST(author)AS peo,
FIRST(sellsum) AS 第一条数据记录 FROM tab_booksort";//创建SQL字符串
            }
            else
            {
                strSql = @"SELECT LAST(BookNames) AS Bookname,LAST(author)AS peo,
LAST(sellsum) AS 最后一条数据记录 FROM tab_booksort";//创建SQL字符串
            }
            OleDbConnection olecn = new OleDbConnection(//创建数据库连接对象
@"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + "db_database.mdb");
            OleDbDataAdapter oledap = new OleDbDataAdapter(strSql, olecn);//创建数据适配器
            DataTable P_dt = new DataTable();//创建数据表
            oledap.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetMessage()
        {
            OleDbConnection olecn = new OleDbConnection(//创建数据库连接对象
                "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + "db_database.mdb");
            OleDbDataAdapter oledap = new OleDbDataAdapter(//创建数据适配器
                "SELECT * FROM tab_booksort", olecn);
            DataTable P_dt = new DataTable();//创建数据表
            oledap.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

    }
}
