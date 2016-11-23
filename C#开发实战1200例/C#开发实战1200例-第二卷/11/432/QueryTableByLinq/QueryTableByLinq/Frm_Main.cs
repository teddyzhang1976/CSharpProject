using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueryTableByLinq
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=WIN-GI7E47AND9R\\LS; database=db_TomeTwo; uid=sa; Pwd=hbyt2008!@#;";//声明连接字符串
            using (SqlConnection conn = new SqlConnection(ConnectionString))//创建数据库连接对象
            {
                string sqlstr = "select * from tb_Bookinfo";//定义查询语句
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);//创建数据桥接器对象
                DataSet ds = new DataSet();//创建数据对象
                da.Fill(ds, "tb_Bookinfo");//填充数据集
                //查找3月份出版的图书
                var result = from b in ds.Tables["tb_Bookinfo"].AsEnumerable()
                             where b.Field<DateTime>("b_pub_date").Month == 3
                             select new
                             {
                                 bookname = b["b_name"].ToString(),
                                 author = b["b_pub_date"].ToString()
                             };
                foreach (var item in result)//遍历图书的书名和出版日期
                {
                   richTextBox1.Text +="书名：" + item.bookname + ";出版日期：" + item.author+"\n";
                }
            }
        }
    }
}
