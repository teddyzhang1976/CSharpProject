using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Take
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            QueryData(Convert.ToInt32(textBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryData(Convert.ToInt32(textBox1.Text));
        }

        private void QueryData(int? cnt)
        {
            string conStr = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";//取连接字符串
            string sql = "select * from EmployeeInfo";//构造sql语句
            DataSet ds = new DataSet();//创建数据集
            using (SqlConnection con = new SqlConnection(conStr))//创建数据连接
            {
                SqlCommand cmd = new SqlCommand(sql, con);//创建Command对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);//创建DataAdapter对象
                sda.Fill(ds, "EmployeeInfo");//填充数据集
            }
            if (cnt == null || cnt <= 0)//如果参数为空,取所有记录
            {
                dataGridView1.DataSource = ds.Tables["EmployeeInfo"];//设置dataGridView1数据源
            }
            else//如果参数不为空,取参数指定的记录数
            {
                IEnumerable<DataRow> query = ds.Tables["EmployeeInfo"].AsEnumerable().Take(cnt ?? 0);//使用LINQ查询数据集
                dataGridView1.DataSource = query.CopyToDataTable();//设置dataGridView1数据源
            }
        }
    }
}
