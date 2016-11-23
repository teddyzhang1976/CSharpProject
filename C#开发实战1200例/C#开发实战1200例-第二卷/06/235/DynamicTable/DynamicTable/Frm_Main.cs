using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DynamicTable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(//创建数据库连接对象
                @"Server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter dap = new SqlDataAdapter(//创建数据适配器对象
                "select * from tb_VenditionInfo", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(//创建数据库连接对象
                @"Server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter dap = new SqlDataAdapter("Corss", con);//创建数据适配器
            dap.SelectCommand.CommandType =//设置命令为存储过程
                CommandType.StoredProcedure;
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }
    }
}
