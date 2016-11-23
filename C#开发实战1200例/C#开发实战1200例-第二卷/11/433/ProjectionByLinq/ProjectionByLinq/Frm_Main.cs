using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectionByLinq
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
                string sqlstr = "select top 5* from tb_Bookinfo";//定义查询语句
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, Conn);//创建数据桥接器对象
                DataSet ds = new DataSet();//创建数据对象
                da.Fill(ds, "tb_Bookinfo");//填充数据集
                //查询图书信息表前3行数据的图书名称和作者
                var result = from b in ds.Tables["tb_Bookinfo"].AsEnumerable()
                             select new
                             {
                                 b_name = b.Field<string>("b_name"),
                                 b_author = b.Field<string>("b_author")
                             };
                foreach (var item in result)//遍历输出查询结果
                {
                    richTextBox1.Text +="图书名称：" + item.b_name + "  ******  作者：" + item.b_author+"\n";
                }
            }
        }
    }
}
