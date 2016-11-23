using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseUpdate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataSet P_ds = GetMessage();//得到数据集
            dgv_Message1.DataSource = P_ds.Tables[0];//设置数据源
            dgv_Message2.DataSource = P_ds.Tables[1];//设置数据源
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            GetEmployee();//更改数据库中的数据
            DataSet P_ds = GetMessage();//得到数据集
            dgv_Message1.DataSource = P_ds.Tables[0];//设置数据源
            dgv_Message2.DataSource = P_ds.Tables[1];//设置数据源
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private void GetEmployee()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"UPDATE tb_Laborage SET 基本工资=(SELECT 基本工资 FROM
tb_AppointedLaborage WHERE 工作时间 = '{0}') WHERE 员工姓名='{1}'",
                cbox_Year.Text,txt_Name.Text);
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);//创建数据库连接对象
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(P_Str_SqlStr,P_sc);//创建数据库命令对象
                P_cmd.ExecuteNonQuery();//执行更改信息操作
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误！");//弹出消息对话框
            }
            finally
            {
                P_sc.Close();//关闭数据库连接
            }
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataSet GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM tb_Laborage SELECT * FROM tb_AppointedLaborage");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataSet P_s = new DataSet();//创建数据表
            P_SqlDataAdapter.Fill(P_s);//填充数据表
            return P_s;//返回数据表
        }
    }
}
