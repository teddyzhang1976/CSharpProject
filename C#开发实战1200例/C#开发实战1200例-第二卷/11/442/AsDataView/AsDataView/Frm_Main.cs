using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AsDataView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";//取连接字符串
            string sql = "select * from WarehouseInfo";//构造sql语句
            DataSet ds = new DataSet();//创建数据集
            using (SqlConnection con = new SqlConnection(conStr))//创建数据连接
            {
                SqlCommand cmd = new SqlCommand(sql, con);//创建Command对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);//创建DataAdapter对象
                sda.Fill(ds, "WarehouseInfo");//填充数据集
            }
            //使用LINQ查询DataSet
            var query = from w in ds.Tables["WarehouseInfo"].AsEnumerable()
                        where w.Field<double>("Area") < 5000
                        select w;
            DataView dv = query.AsDataView();//将LINQ查询结果集转换为DataView
            dataGridView1.DataSource = dv;
        }
    }
}
