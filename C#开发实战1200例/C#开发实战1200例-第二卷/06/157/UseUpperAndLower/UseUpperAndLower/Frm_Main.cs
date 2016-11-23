using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseUpperAndLower
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetString();//设置数据源
            dgv_Message.Columns[1].Width = 130;//设置列宽度
            dgv_Message.Columns[2].Width = 130;//设置列宽度
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetString()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT friendname AS 字符串,LOWER(friendname)
AS 全部转换为小写,UPPER(friendname) AS 全部转换为大写
FROM tb_string");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }
    }
}
