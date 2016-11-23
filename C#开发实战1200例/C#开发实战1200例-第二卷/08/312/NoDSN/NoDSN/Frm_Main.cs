using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace NoDSN
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                string odbcConStr =//创建数据库连接字符串
                    @"driver=SQL Server;server=WIN-GI7E47AND9R\LS;UID=sa;Pwd=hbyt2008!@#;database=db_TomeTwo";
                OdbcConnection odbcCon = new OdbcConnection(odbcConStr);//创建数据库连接对象
                OdbcDataAdapter da =//创建数据适配器对象
                    new OdbcDataAdapter("select * from 帐单", odbcCon);
                DataTable dt = new DataTable();//创建数据表
                da.Fill(dt);//填充数据表
                this.dgv_Message.DataSource =//设置数据源
                    dt.DefaultView;
            }
            catch (Exception ey)//捕获异常
            {
                MessageBox.Show(ey.Message);//弹出消息对话框
            }
        }
    }
}
