using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ShareAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strCon = //设置数据库连接字符串
@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=
\\明日公共文件夹\公司公共资源\数据文件\test.mdb";
            OleDbConnection OleCon = new OleDbConnection(strCon);//创建数据库连接对象
            OleDbDataAdapter da = new OleDbDataAdapter(//创建数据适配器
                "select * from 帐目", OleCon);
            DataSet ds = new DataSet();//创建数据集
            da.Fill(ds, "MyDataTable");//填充数据集
            dgv_Message.DataSource =//设置数据源
                ds.Tables[0].DefaultView;
        }
    }
}
