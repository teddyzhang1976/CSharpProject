using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseProcedure
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showinfo();//显示数据
        }

        //自定义方法，显示数据
        private void showinfo()
        {
            using (SqlDataAdapter da = new SqlDataAdapter(
                "select * from 员工表", con))//建立SQL语旬与数据库的连接
            {
                DataTable dt = new DataTable();//实例化DataTable类
                da.Fill(dt);//添加SQL语句并执行
                DataView dv = new DataView(dt);//实例化DataView
                this.dataGridView1.DataSource = dv;//显示数据
            }
        }
        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ID();//自定义方法，自动生成编号
            this.textBox1.Enabled = false;//按钮不可用
        }
        //自定义方法
        private string ID()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();//实例化SqlCommand类
                cmd.Connection = con;//设置数据库的连接
                con.Open();//打开数据库的连接
                cmd.CommandType = CommandType.StoredProcedure;//设置类型为存储过程
                cmd.CommandText = "proc_Id";//存储过程的名称
                SqlParameter sqlOutput = new SqlParameter("@Id", SqlDbType.VarChar, 8);//获取最后一个记录的编号
                sqlOutput.Direction = ParameterDirection.Output;//参数输出
                cmd.Parameters.Add(sqlOutput);//添加编号
                cmd.ExecuteNonQuery();//执行SQL语句
                con.Close();//关闭连接
                return cmd.Parameters["@Id"].Value.ToString();//返回编号的值
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
                return null;
            }
        }
        //保存
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())//创建SqlCommand对象
            {
                try
                {
                    cmd.Connection = con;//设置连接属性
                    con.Open();//打开数据库的连接
                    cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    cmd.CommandText = "proc_insert";//存储过程
                    SqlParameter[] prams =//创建参数数组
                              {
                                new SqlParameter("@id", SqlDbType.VarChar, 8),
                                new SqlParameter("@name", SqlDbType.VarChar, 50),
                                new SqlParameter("@money", SqlDbType.Float),
                                new SqlParameter("@talk", SqlDbType.VarChar, 50)
                              };
                    prams[0].Value = this.textBox1.Text;//设置参数值
                    prams[1].Value = this.textBox2.Text;//设置参数值
                    prams[2].Value = this.textBox4.Text;//设置参数值
                    prams[3].Value = this.textBox5.Text;//设置参数值
                    foreach (SqlParameter parameter in prams)
                        cmd.Parameters.Add(parameter);//添加参数
                    SqlParameter sqlpar =//得到参数对象
                        cmd.Parameters.Add("@Return", SqlDbType.Int);
                    sqlpar.Direction =//设置参数类型
                        ParameterDirection.ReturnValue;//获取返回值
                    cmd.ExecuteNonQuery();//执行SQL语句
                    con.Close();//关闭数据库的连接
                }
                catch (Exception eu)
                {
                    MessageBox.Show(eu.Message, "错误！");
                    con.Close();//关数数据库连接
                    return;//退出事件
                }
                int i = Convert.ToInt16(cmd.Parameters["@Return"].Value.ToString());//返回影响的行数
                if (i == 1)
                {
                    MessageBox.Show("添加过程成功");//弹出消息对话框
                }
                else if (i == -1)
                {
                    MessageBox.Show("添加过程失败");//弹出消息对话框
                }
                showinfo();//显示添加后的结果
            }
        }
    }
}

