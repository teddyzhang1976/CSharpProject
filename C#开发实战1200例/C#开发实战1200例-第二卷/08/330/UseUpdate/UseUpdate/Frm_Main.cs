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

        private DataSet G_st = new DataSet();//声明表字段

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_st.Tables.Add(new DataTable());
            GetMessage();//填充表
            dgv_Message.DataSource = G_st.Tables[0];//设置数据源
            dgv_Message.Columns[0].Visible = false;//隐藏主键列
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter();//创建数据适配器
            SqlCommand P_cmd = new SqlCommand(//创建命令对象
                @"UPDATE tb_Student_Copy SET 学生姓名=@name,学生年龄=@age,性别=@sex,家庭住址=@address
WHERE id=@id",
                new SqlConnection(@"server=.\EXPRESS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;"));
            P_cmd.Parameters.Add("@id", SqlDbType.Int,10,"id");//设置参数
            P_cmd.Parameters.Add("@name", SqlDbType.VarChar, 10, "学生姓名");//设置参数
            P_cmd.Parameters.Add("@age", SqlDbType.Int, 10, "学生年龄");//设置参数
            P_cmd.Parameters.Add("@sex", SqlDbType.NChar, 2, "性别");//设置参数
            P_cmd.Parameters.Add("address", SqlDbType.VarChar, 50, "家庭住址");//设置参数
            P_SqlDataAdapter.UpdateCommand = P_cmd;//设置UpdateCommand属性
            P_SqlDataAdapter.Update(G_st.Tables[0]);//更新数据库中数据
            G_st.AcceptChanges();//提交修改
            MessageBox.Show("更改成功！","提示！");//弹出消息对话框
            GetMessage();//填充表
            dgv_Message.DataSource = G_st.Tables[0];//设置数据源
            dgv_Message.Columns[0].Visible = false;//隐藏主键列
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private void GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=mrwxk\wangxiaoke;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM tb_Student_Copy");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            P_SqlDataAdapter.Fill(G_st.Tables[0]);//填充数据表
        }

        private void dgv_Message_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            G_st.Tables[0].Rows[e.RowIndex][e.ColumnIndex] = //同步DataGridView控件中的数据
                dgv_Message.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

    }
}
