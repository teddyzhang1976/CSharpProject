using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConnectToSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                string ConStr =//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;user id=sa;pwd=;database=db_TomeTwo";
                SqlConnection con = new SqlConnection(ConStr);//创建数据库连接对象
                string SqlStr = "select * from 帐单";//创建SQL查询字符串
                SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);//创建数据适配器对象
                DataSet ds = new DataSet();//创建数据表
                ada.Fill(ds);//填充数据集
                this.dgv_Message.DataSource =//设置数据源
                    ds.Tables[0].DefaultView;
            }
            catch(Exception ex)//捕获异常
            {
                MessageBox.Show(ex.Message,"提示！");//弹出消息对话框
            }
        }
    }
}
