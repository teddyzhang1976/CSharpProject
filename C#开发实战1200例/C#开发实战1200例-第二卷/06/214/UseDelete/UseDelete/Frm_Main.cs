using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseDelete
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RemoveStudent();//删除数据库中的记录
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        /// <summary>
        /// 删除数据库中的记录
        /// </summary>
        private void RemoveStudent()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"DELETE FROM tb_Student 
WHERE 学生编号 
IN 
(SELECT 学生编号 FROM tb_Student WHERE 性别='女'
AND 出生年月='1981/12/12' AND 所学专业='会计学')");
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(P_Str_SqlStr,P_sc);//创建命令对象
                P_cmd.ExecuteNonQuery();//执行SQL语句
            }
            catch (Exception ex)//捕获异常
            {
                MessageBox.Show(ex.Message, "错误！");//弹出消息对话框
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
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM tb_Student");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

    }
}
