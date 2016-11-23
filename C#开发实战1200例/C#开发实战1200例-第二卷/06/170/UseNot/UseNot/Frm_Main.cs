using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseNot
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetStudent("SELECT * FROM tb_Grade");//设置数据源
            rbtn_One.CheckedChanged += (senders, es) =>
                {
                    if (((RadioButton)senders).Checked)//判断是否选中
                    {
                        dgv_Message.DataSource =//设置数据源
                            GetStudent(string.Format("SELECT * FROM tb_Grade WHERE 高数>80"));
                    }
                };
            rbtn_Two.CheckedChanged += (senders, es) =>
                {
                    if (((RadioButton)senders).Checked)//判断是否选中
                    {
                        dgv_Message.DataSource =//设置数据源
                            GetStudent(string.Format("SELECT * FROM tb_Grade WHERE 数据结构<60"));
                    }
                };
            rbtn_Three.CheckedChanged += (senders, es) =>
                {
                    if (((RadioButton)senders).Checked)//判断是否选中
                    {
                        dgv_Message.DataSource =//设置数据源
                            GetStudent(string.Format(
                            "SELECT * FROM tb_Grade WHERE 软件工程>90 AND 外语 NOT BETWEEN 70 AND 85"));
                    }
                };
        }

        /// <summary>
        /// 根据指定的SQL语句查询数据库信息
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
    }
}
