using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UseFunction
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetStudent();//设置数据源
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetStudent()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                "db_Test.mdb" + ";Persist Security Info=False");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT 员工姓名, FORMAT(出生日期,'yyyy年mm月dd日')
AS 出生日期, MID(出生日期,1,7) AS
出生年月 FROM 员工生日表");
            OleDbDataAdapter P_OLEDBDataAdapter = new OleDbDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_OLEDBDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
                "db_Test.mdb" + ";Persist Security Info=False");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM 员工生日表");
            OleDbDataAdapter P_OLEDBDataAdapter = new OleDbDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_OLEDBDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

    }
}
