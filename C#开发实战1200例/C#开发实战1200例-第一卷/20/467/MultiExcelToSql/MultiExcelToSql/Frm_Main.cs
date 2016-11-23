using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MultiExcelToSql
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openFileDialog1.Title = "选择Excel文件";//设置打开对话框标题
            openFileDialog1.Multiselect = true;//设置打开对话框中可以多选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)//遍历所有选择的文件
                    txt_Path.Text += openFileDialog1.FileNames[i] + ",";//在文本框中显示Excel文件名
            }
        }

        private void ckbox_Winfows_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbox_Windows.Checked)//如果Windows身份验证复选框选中
            {
                ckbox_SQL.Checked = false;//设置SQL Server身份验证复选框取消选中
                txt_Pwd.Enabled = txt_Name.Enabled = false;//设置用户名和密码文本框不可用
                //定义SQL语句
                string P_str_Con = "Data Source=" + txt_Server.Text + ";Database=master;Integrated Security=SSPI;";
                cbox_Server.DataSource = GetTable(P_str_Con);//为下拉列表指定数据源
                cbox_Server.DisplayMember = "name";//设置下拉列表中显示的字段名称
                cbox_Server.ValueMember = "name";//设置下拉列表中显示的值名称
                if (cbox_Server.Items.Count > 0)//如果下拉列表中有项
                    cbox_Server.SelectedIndex = 0;//设置默认选择第一项
            }
        }

        private void ckbox_SQL_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbox_SQL.Checked)//如果Windows身份验证复选框选中
            {
                ckbox_Windows.Checked = false;//设置Windows身份验证复选框取消选中
                txt_Pwd.Enabled = txt_Name.Enabled = true;//设置用户名和密码文本框可用
                txt_Name.Focus();//使用户名文本框获得鼠标焦点
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //定义SQL语句
            string P_str_Con = "Data Source=" + txt_Server.Text + ";Database=master;Uid=" + txt_Name.Text + ";Pwd=hbyt2008!@#;" + txt_Pwd.Text + ";";
            cbox_Server.DataSource = GetTable(P_str_Con);//为下拉列表指定数据源
            cbox_Server.DisplayMember = "name";//设置下拉列表中显示的字段名称
            cbox_Server.ValueMember = "name";//设置下拉列表中显示的值名称
            if (cbox_Server.Items.Count > 0)//如果下拉列表中有项
                cbox_Server.SelectedIndex = 0;//设置默认选择第一项
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string[] P_str_Names = txt_Path.Text.Split(',');//存储所有选择的Excel文件名
            string P_str_Name = "";//存储遍历到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//实例化泛型集合对象，用来存储工作表名称
            for (int i = 0; i < P_str_Names.Length - 1; i++)//遍历所有选择的Excel文件名
            {
                P_str_Name = P_str_Names[i];//记录遍历到的Excel文件名
                P_list_SheetNames = GetSheetName(P_str_Name);//获取Excel文件中的所有工作表名
                for (int j = 0; j < P_list_SheetNames.Count; j++)//遍历所有工作表
                {
                    if (ckbox_Windows.Checked)//如果用Windows身份验证登录Sql Server
                        ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Initial Catalog =" + cbox_Server.Text + ";Integrated Security=SSPI;");//将工作表内容导出到Sql Server
                    else if (ckbox_SQL.Checked)//如果用Sql Server身份验证登录Sql Server
                        ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Database=" + cbox_Server.Text + ";Uid=" + txt_Name.Text + ";Pwd=hbyt2008!@#;" + txt_Pwd.Text + ";");//将工作表内容导出到Sql Server
                }
            }
            MessageBox.Show("已经将所有选择的Excel工作表导入到了Sql Server数据库中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataTable GetTable(string P_str_Sql)//获取指定服务器中的所有数据库
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(P_str_Sql);//实例化数据库连接对象
                SqlDataAdapter sqlda = new SqlDataAdapter("select name from sysdatabases ", sqlcon);//实例化数据桥接器对象
                DataTable DTable = new DataTable("sysdatabases");//实例化DataTable对象
                sqlda.Fill(DTable);//填充DataTable数据表
                return DTable;//返回DataTable数据表
            }
            catch
            {
                return null;//返回null
            }
        }

        private List<string> GetSheetName(string P_str_Excel)//获取所有工作表名称
        {
            List<string> P_list_SheetName = new List<string>();//实例化泛型集合对象
            //连接Excel数据库
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0");
            olecon.Open();//打开数据库连接
            System.Data.DataTable DTable = olecon.GetSchema("Tables");//实例化表对象
            DataTableReader DTReader = new DataTableReader(DTable);//实例化表读取对象
            while (DTReader.Read())//循环读取
            {
                string P_str_Name = DTReader["Table_Name"].ToString().Replace('$', ' ').Trim();//记录工作表名称
                if (!P_list_SheetName.Contains(P_str_Name))//判断泛型集合中是否已经存在该工作表名称
                    P_list_SheetName.Add(P_str_Name);//将工作表名添加到泛型集合中
            }
            DTable = null;//清空表对象
            DTReader = null;//清空表读取对象
            olecon.Close();//关闭数据库连接
            return P_list_SheetName;//返回得到的泛型集合
        }

        public void ImportDataToSql(string P_str_Excel, string P_str_SheetName, string P_str_SqlCon)//将工作表内容导出到Sql Server
        {
            DataSet myds = new DataSet();//实例化数据集对象
            try
            {
                //获得全部数据    
                string P_str_OledbCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0;";
                OleDbConnection oledbcon = new OleDbConnection(P_str_OledbCon);//实例化Oledb数据库连接对象
                string P_str_ExcelSql = "";//定义变量，用来记录要执行的Excel查询语句
                OleDbDataAdapter oledbda = null;//实例化Oledb数据桥接器对象
                P_str_ExcelSql = string.Format("select * from [{0}$]", P_str_SheetName);//记录要执行的Excel查询语句
                oledbda = new OleDbDataAdapter(P_str_ExcelSql, P_str_OledbCon);//使用数据桥接器执行Excel查询
                oledbda.Fill(myds, P_str_SheetName);//填充数据
                string P_str_CreateSql = string.Format("create table {0}(", P_str_SheetName);//定义变量，用来记录创建表的SQL语句
                foreach (DataColumn c in myds.Tables[0].Columns)//遍历数据集中的所有行
                {
                    P_str_CreateSql += string.Format("[{0}] text,", c.ColumnName);//在表中创建字段
                }
                P_str_CreateSql = P_str_CreateSql + ")";//完善创建表的SQL语句
                using (SqlConnection sqlcon = new SqlConnection(P_str_SqlCon))//实例化SQL数据库连接对象
                {
                    sqlcon.Open();//打开数据库连接
                    SqlCommand sqlcmd = sqlcon.CreateCommand();//实例化SqlCommand执行命令对象
                    sqlcmd.CommandText = P_str_CreateSql;//指定要执行的SQL语句
                    sqlcmd.ExecuteNonQuery();//执行操作
                    sqlcon.Close();//关闭数据连接
                }
                using (SqlBulkCopy bcp = new SqlBulkCopy(P_str_SqlCon))//用bcp导入数据 
                {
                    bcp.BatchSize = 100;//每次传输的行数    
                    bcp.DestinationTableName = P_str_SheetName;//定义目标表    
                    bcp.WriteToServer(myds.Tables[0]);//将数据写入Sql Server数据表
                }
            }
            catch
            {
                MessageBox.Show("Sql Server数据库中已经存在" + P_str_SheetName + "表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
