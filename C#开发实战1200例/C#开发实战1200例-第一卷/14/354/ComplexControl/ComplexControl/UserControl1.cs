using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ComplexControl
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            BindData();
        }

        public void BindData()
        {
            SqlConnection con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne;");//创建数据库连接对象
            con.Open();//打开数据库连接
            SqlDataAdapter sda = new SqlDataAdapter("Select * From tb_Student", con);//创建桥接器对象
            DataTable dt = new DataTable();//创建DataTable对象
            try
            {
                sda.Fill(dt);//填充DataTable
            }
            catch (Exception ex)
            {
                throw ex;//抛出异常
            }
            bindingSource1.DataSource = dt;//指定BindingSource数据源
            dataGridView1.DataSource = bindingSource1;//将BindingSource指定给DataGridView
        }
    }
}
