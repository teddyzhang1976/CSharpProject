using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SortByLinq
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=WIN-GI7E47AND9R\\LS; database=db_TomeTwo; uid=sa; Pwd=hbyt2008!@#;";//连接字符串
            using (SqlConnection Conn = new SqlConnection(ConnectionString))//创建数据库连接对象
            {
                string sqlstr = "select * from tb_Bookinfo";//定义查询语句
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, Conn);//创建数据桥接器对象
                DataSet ds = new DataSet();//创建数据对象
                da.Fill(ds, "tb_Bookinfo");//填充数据集
                //按照单价降序排序
                var result = from b in ds.Tables["tb_Bookinfo"].AsEnumerable()
                             orderby b.Field<decimal>("b_price") descending
                             select new
                             {
                                 b_name = b["b_name"].ToString(),
                                 b_price = b["b_price"].ToString()
                             };
                foreach (var item in result)//遍历输出查询结果
                {
                    richTextBox1.Text+="图书名称：" + item.b_name + "  ******  单价：" + item.b_price+"\n";
                }
            }
        }
    }
}
