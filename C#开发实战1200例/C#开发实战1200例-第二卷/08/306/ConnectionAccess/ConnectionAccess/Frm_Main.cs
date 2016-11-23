using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ConnectionAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string ConStr = string.Format(//设置数据库连接字符串
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data source='{0}\test.mdb'",
                Application.StartupPath);
            OleDbConnection oleCon = new OleDbConnection(ConStr);//创建数据库连接对象
            OleDbDataAdapter oleDap = new OleDbDataAdapter(//创建数据适配器对象
                "select * from 帐目", oleCon);
            DataSet ds = new DataSet();//创建数据集
            oleDap.Fill(ds, "帐目");//填充数据集
            this.dataGridView1.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
            oleCon.Close();//关闭数据库连接
            oleCon.Dispose();//释放连接资源
        }
    }
}
