using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OperateElementByLinq
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
                da.Fill(ds, "tb_Register");//填充数据集
                //查询全部药品登记信息
                var result = from d in ds.Tables["tb_Register"].AsEnumerable()
                             select d;
                if (result.Count() > 0)
                {
                    DataRow last = result.Last();//返回结果集中的最后一行
                    richTextBox1.Text ="药品名称：" + last.Field<string>("药品名称") + "  ******  生产厂家：" + last.Field<string>("生产厂家");
                }
            }
        }
    }
}
