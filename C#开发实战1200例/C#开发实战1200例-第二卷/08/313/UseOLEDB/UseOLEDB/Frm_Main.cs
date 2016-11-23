using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UseOLEDB
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
                string strOledbCon =//创建数据库连接字符串
@"Provider=SQLOLEDB;Data Source=LVSHUANG\SHJ; 
Integrated Security = SSPI;Persist Security Info=False;Initial Catalog=db_TomeTwo";
                using (OleDbConnection OledbCon = new OleDbConnection())//创建数据库连接对象
                {
                    OledbCon.ConnectionString = strOledbCon;//设置数据库连接字符串
                    OledbCon.Open();//打开数据库连接
                    OleDbDataAdapter OledbDat = new OleDbDataAdapter(//创建数据适配器对象
                        "select top 1 * from 帐单", strOledbCon);
                    DataTable dt = new DataTable();//创建数据表
                    OledbDat.Fill(dt);//填充数据表
                    this.txt_Name.Text = dt.Rows[0][0].ToString().Trim();//显示数据信息
                    this.txt_Money.Text = dt.Rows[0][1].ToString().Trim();//显示数据信息
                    this.txt_Bonus.Text = dt.Rows[0][3].ToString().Trim();//显示数据信息
                    this.txt_Eat.Text = dt.Rows[0][4].ToString().Trim();//显示数据信息
                }
            }
            catch (Exception y)//捕获异常
            {
                MessageBox.Show(y.Message);//弹出消息对话框
            }
        }
    }
}
