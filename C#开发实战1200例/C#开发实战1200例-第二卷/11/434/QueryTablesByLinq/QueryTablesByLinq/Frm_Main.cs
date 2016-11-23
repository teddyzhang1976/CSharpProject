using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueryTablesByLinq
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=WIN-GI7E47AND9R\\LS; database=db_TomeTwo; uid=sa; Pwd=hbyt2008!@#;";//声明连接字符串
            using (SqlConnection Conn = new SqlConnection(ConnectionString))//创建数据库连接对象
            {
                string sqlstr = "select * from tb_Register";//定义查询语句
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, Conn);//创建数据桥接器对象
                DataSet ds = new DataSet();//创建数据对象
                da.Fill(ds, "register");//填充第一个数据表数据到DataSet
                sqlstr = "select * from tb_Sale";//定义查询语句
                da.SelectCommand.CommandText = sqlstr;//指定第二条查询语句
                da.Fill(ds, "sale");//填充第二个数据表数据到DataSet
                //查询有销售记录的药品信息
                var result = from r in ds.Tables["register"].AsEnumerable()
                             join s in ds.Tables["sale"].AsEnumerable()
                             on r.Field<string>("药品编号") equals s.Field<string>("药品编号")
                             select new
                             {
                                 drug_name = r["药品名称"].ToString(),
                                 drug_factory = r["生产厂家"].ToString(),
                                 drug_sale = s["销售额"].ToString()
                             };
                foreach (var item in result)			//遍历输出查询结果
                {
                    richTextBox1.Text += "药品名称：" + item.drug_name + "******生产厂家：" + item.drug_factory + "******销售额：" + item.drug_sale + "\n";
                }
            }
        }
    }
}
