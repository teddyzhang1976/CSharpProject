using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseCOMPUTEBY
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
            DataSet P_ds = GetPay();//得到数据集
            txt_Pay1.Text = P_ds.Tables[1].Rows[0][0].ToString();//得到部门总工资
            txt_Pay2.Text = P_ds.Tables[3].Rows[0][0].ToString();//得到部门总工资
            txt_Pay3.Text = P_ds.Tables[5].Rows[0][0].ToString();//得到部门总工资
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataSet GetPay()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=LVSHUANG\SHJ;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM tb_Employee ORDER BY 所属部门 COMPUTE SUM(工资) BY 所属部门");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataSet P_ds = new DataSet();//创建数据集
            P_SqlDataAdapter.Fill(P_ds);//填充数据集
            return P_ds;//返回数据集
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=LVSHUANG\SHJ;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM tb_Employee");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

    }
}
