using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace UseDSN
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            OdbcConnection odbcCon =//创数据库连接对象
                new OdbcConnection("DSN=MyData;uid=sa;Pwd=hbyt2008!@#;");
            try
            {
                OdbcDataAdapter odbcDat =//创建数据适配器
                    new OdbcDataAdapter("SELECT * from 帐单", odbcCon);
                DataTable dt = new DataTable("帐单");//创建数据表
                odbcDat.Fill(dt);//填充数据表
                this.dataGridView1.DataSource = dt.DefaultView;//设置数据源
            }
            catch (Exception ey)//捕获异常
            {
                MessageBox.Show(ey.Message);//弹出消息对话框
            }
        }
    }
}
