using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;


namespace RevertDataBase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=master"))
            {
                DataTable dt = new DataTable();//创建数据表
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器
                    "select name from sysdatabases", con);
                da.Fill(dt);//填充数据表
                this.cbox_DataBase.DataSource = dt.DefaultView;//设置数据源
                this.cbox_DataBase.DisplayMember = "name";//设置显示属性
                this.cbox_DataBase.ValueMember = "name";//设置实际值
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_Path.Text = this.openFileDialog1.FileName;//显示备份文件路径信息
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restore();//还原数据库
        }

        private void Restore()
        {
            string path = this.txt_Path.Text; //得到备份路径及数据库名称
            string dbname = this.cbox_DataBase.Text;//得到将要还原的数据库名称
            string SqlStr1 = //创建数据库连接字符串
@"Server=LVSHUANG\SHJ;database='" + this.cbox_DataBase.Text + "';Uid=sa;Pwd=hbyt2008!@#;";
            string SqlStr2 =//创建SQL查询语句
                "use master restore database " + dbname + " from disk='" + path + "'";
            using (SqlConnection con = new SqlConnection(SqlStr1))//创建数据库连接对象
            {
                con.Open();//打开数据库连接
                try
                {
                    SqlCommand cmd = new SqlCommand(SqlStr2,con);//创建命令对象
                    cmd.Connection = con;//设置连接属性
                    cmd.ExecuteNonQuery();//执行SQL命令
                    MessageBox.Show("还原数据成功");//弹出消息对话框
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,//弹出消息对话框
                        "还原失败，请确保还原项与库对应");
                }
                finally
                {
                    con.Close();//关闭数据库连接
                }
            }
        }
    }
}
