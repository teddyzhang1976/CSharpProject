using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Data.SqlClient;

namespace BackUpDataBase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(SqlConnection con=new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=master"))
            {
                DataTable dt = new DataTable();//创建数据表
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器对象
                    "select name from sysdatabases", con);
                da.Fill(dt);//填充数据表
                this.comboBox1.DataSource = dt.DefaultView;//设置数据源
                this.comboBox1.DisplayMember = "name";//设置显示属性
                this.comboBox1.ValueMember = "name";//设置实际值
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beifenInfo();//备份数据库
        }

        public void beifenInfo()
        {
            try
            {
                sd.InitialDirectory = Application.StartupPath + "\\";//默认路径为D：
                sd.FilterIndex = 1;//默认值为第一个
                sd.RestoreDirectory = true;//重新定位保存路径
                sd.Filter = "备份文件 (*.bak)|*.bak|所有文件 (*.*)|*.*";//设置筛选文件类型
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(sd.FileName.ToString()))
                    {
                        SqlConnection con = new SqlConnection();//创建数据库连接对象
                        con.ConnectionString = @"server=LVSHUANG\SHJ;UID=sa;Pwd=hbyt2008!@#;database='" + this.comboBox1.Text + "'";
                        con.Open();//打开数据连接
                        SqlCommand com = new SqlCommand();//创建命令对象
                        this.textBox1.Text = sd.FileName.ToString();//显示文件路径信息
                        com.CommandText = "BACKUP DATABASE " + this.comboBox1.Text +//设置要执行的SQL语句
                            " TO DISK = '" + sd.FileName.ToString() + "'";
                        com.Connection = con;//设置连接属性
                        com.ExecuteNonQuery();//执行SQL语句
                        con.Close();//关闭数据库连接
                        MessageBox.Show("数据备份成功！");//弹出消息对话框
                    }
                    else
                    {
                        MessageBox.Show("请重新命名！");//弹出消息对话框
                    }
                }
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);//弹出消息对话框
            }
        }
    }
}
