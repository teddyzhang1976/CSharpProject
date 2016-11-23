using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UseFormat
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(//创建数据库连接对象
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" 
                + "db_Test.mdb" + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器对象
                "SELECT * FROM 员工生日表;", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据表
            dgv_Message.DataSource = ds.Tables[0].DefaultView;//设置数据源
        }

        private void btn_Format_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(//创建数据库连接对象
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + "db_Test.mdb" + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器对象
                @"SELECT 员工姓名, 出生日期 AS 格式化前出生日期,
FORMAT(出生日期,'yyyy年mm月dd日') AS 格式化后出生日期 FROM 员工生日表", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据表
            dgv_Message.DataSource = ds.Tables[0].DefaultView;//设置数据源
            dgv_Message.Columns[1].Width = 150;
            dgv_Message.Columns[2].Width = 150;
        }
    }
}
