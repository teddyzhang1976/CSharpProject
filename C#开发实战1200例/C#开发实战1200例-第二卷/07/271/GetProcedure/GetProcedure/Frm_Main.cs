using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace GetProcedure
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=WIN-GI7E47AND9R\\LS;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");//连接数据库
            SqlDataAdapter dap = new SqlDataAdapter("select name as 存储过程名称,crdate as 创建时间,refdate as 最后一次修改时间 from sysobjects where xtype ='p'", con);//获取所有存储过程
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充数据
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//将获得的存储过程显示在DataGridView控件中
        }
    }
}
