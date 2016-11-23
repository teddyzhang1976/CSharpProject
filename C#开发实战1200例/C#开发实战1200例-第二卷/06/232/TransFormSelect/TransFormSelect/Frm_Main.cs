using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TransFormSelect
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
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                "book.mdb" + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器
                "select * from 图书排行", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(//创建数据库连接对象
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "book.mdb"
                + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器
                @"TRANSFORM  SUM(数量) AS 库存数量 SELECT 
语言类别 FROM 图书排行 WHERE 语言类别  IN 
( 'c','VB','java') GROUP BY (语言类别) 
PIVOT 分析时间", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Result.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }
    }
}
