using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UseTransForm
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
                + "dt.mdb" + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器
                "select * from 部门销售额表 ", con);
            DataSet ds = new DataSet();//创建数据集
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            string strIN = "";
            if (cb_SoftWare.Checked == true)//如果被选中
            {
                strIN = cb_SoftWare.Text;//添加条件
            }
            if (cb_HardWare.Checked == true)//如果被选中
            {
                if (strIN != "")//如果条件不为空
                    strIN = strIN + "','" + cb_HardWare.Text;//累加条件
                else
                    strIN = cb_HardWare.Text;//添加条件
            }
            if (cb_NetWork.Checked == true)//如果被选中
            {
                if (strIN != "")//如果条件不为空
                    strIN = strIN + "','" + cb_NetWork.Text;//累加条条
                else
                    strIN = cb_NetWork.Text;//添加条件
            }
            if (strIN == "")//如果条件为空
                return;
            OleDbConnection con = new OleDbConnection(//创建数据库连接对象
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                "dt.mdb" + ";Persist Security Info=False");
            OleDbDataAdapter dap = new OleDbDataAdapter(//创建数据适配器对象
                "transform  sum(" + cbox_GatherField.Text + 
                ") as 数据 select " + cbox_RowField.Text +
                " from 部门销售额表 where " + cbox_RowField.Text + 
                "  in('" + strIN +"')  group by (" + cbox_RowField.Text +
                ")  pivot " + cbox_ColumnField.Text + "", con);
            DataSet ds = new DataSet();//创建数据集对象
            dap.Fill(ds, "table");//填充数据集
            dgv_Message.DataSource = ds.Tables[0];//设置数据源
        }
    }
}
