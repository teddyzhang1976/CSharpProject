using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FindOperator
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cbox_Field.DataSource = GetField("tb_student");//设置数据源
            cbox_Field.DisplayMember = "Name";//设置显示的属性
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetStudent(SQLGenerator(//设置数据源
                "tb_Student", cbox_Field.Text, cbox_Operator.Text,
                txt_Condition.Text));
        }

        /// <summary>
        /// 查询数据表中字段信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private List<StudentField> GetField(string TableName)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "select c.name from syscolumns c,sysobjects a where a.name='{0}' and a.id=c.id",
                TableName);
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            List<StudentField> P_List_StudentField = new List<StudentField>();
            for (int i = 0; i < P_dt.Rows.Count; i++)
            {
                P_List_StudentField.Add(new StudentField()//向集合添加数据
                { Name = P_dt.Rows[i][0].ToString() });
            }
            return P_List_StudentField;//返回数据表
        }

        /// <summary>
        /// 动态生成SQL语句
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Field">字段名</param>
        /// <param name="Operator">操作符</param>
        /// <param name="Condition">条件</param>
        /// <returns>方法返回SQL语句</returns>
        private string SQLGenerator(string Table,string Field,string Operator,string Condition)
        {
            string P_Str = "SELECT * FROM "+Table;//生成SQL语句
            switch (Operator)
            {
                case "%Like%":
                    P_Str += string.Format(" WHERE {0} Like '%{1}%'",Field,Condition);//添加字符串
                    break;
                case "Like%":
                    P_Str += string.Format(" WHERE {0} Like '{1}%'", Field, Condition);//添加字符串
                    break;
                case "%Like":
                    P_Str += string.Format(" WHERE {0} Like '%{1}'", Field, Condition);//添加字符串
                    break;
                default:
                    if (Condition==string.Empty)
                    {
                        P_Str += string.Format(" WHERE {0} IS null OR {0}=''", Field);//添加字符串
                        break;
                    }
                    P_Str += string.Format(" WHERE {0} {1} '{2}'",//添加字符串
                        Field, Operator, Condition);
                    break;
            }
            return P_Str;//方法返回字符串对象
        }

        /// <summary>
        /// 根据指定SQL语句查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetStudent(string SQL)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                SQL, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
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

    class StudentField
    {
        public string Name { get; set; }//定义属性

        public override string ToString()//重写ToString方法
        {
            return Name.ToString();
        }
    }
}
