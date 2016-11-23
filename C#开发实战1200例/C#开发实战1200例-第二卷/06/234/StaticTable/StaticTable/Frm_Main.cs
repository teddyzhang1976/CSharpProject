using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StaticTable
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
            SqlDataAdapter dap = new SqlDataAdapter(//创建数据适配器
                "SELECT * FROM tb_VenditionInfo", con);
            DataSet ds = new DataSet();//设置数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }

        private void btn_Name_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(//创建数据库连接对象
@"Server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter dap = new SqlDataAdapter(//创建数据适配器
@"SELECT 所在部门, SUM(CASE 员工姓名 WHEN '李金明' THEN
销售业绩 ELSE NULL END)AS [李金明],SUM(CASE 员工姓名 WHEN
'周可人' THEN 销售业绩 ELSE NULL END)as [周可人] ,SUM(
CASE 员工姓名 WHEN '韩运' THEN 销售业绩 ELSE NULL END)
AS [韩运],SUM(CASE 员工姓名 WHEN '司徒南' THEN 销售业绩
ELSE NULL END)AS [司徒南],SUM(CASE 员工姓名 WHEN '史佳金'
THEN 销售业绩 ELSE NULL END)AS [史佳金]  FROM
tb_VenditionInfo GROUP BY 所在部门", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds);//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }

        private void btn_Department_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(//创建数据库连接对象
@"Server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter dap = new SqlDataAdapter(//创建数据适配器
@"SELECT 员工姓名, SUM(CASE 所在部门 WHEN '食品部' THEN
销售业绩 ELSE NULL END) AS [食品部业绩],SUM(CASE
所在部门 WHEN '家电部' THEN 销售业绩 ELSE NULL END)
AS [家电部业绩] FROM tb_VenditionInfo GROUP BY 员工姓名", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds);//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
            dgv_Message.Columns[2].Width = 200;//设置列宽度
        }
    }
}
