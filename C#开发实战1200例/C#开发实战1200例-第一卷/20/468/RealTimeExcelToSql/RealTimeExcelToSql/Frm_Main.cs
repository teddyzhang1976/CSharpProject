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
using System.Runtime.InteropServices;

namespace RealTimeExcelToSql
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        #region 为INI文件中指定的节点取得字符串
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region 修改INI文件中内容
        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region 从INI文件中读取指定节点的内容
        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="def">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion

        string M_str_Name = Application.StartupPath + "\\Set.ini";//定义要读取的INI文件

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            txt_Path.Text = ReadString("Set", "Excel", "", M_str_Name);//读取默认的Excel文件
            txt_Server.Text = ReadString("Set", "Server", "", M_str_Name);//读取SQL服务器
            if (ReadString("Set", "Login", "", M_str_Name) == "0")//判断SQL登录模式的值是否为0
            {
                ckbox_Windows.Checked = true;//设置Windows身份验证复选框选中
                ckbox_SQL.Checked = false;//读取SQL服务器
                txt_Name.Text = txt_Pwd.Text = "";//清空用户名和文本框中的文本
            }
            else if (ReadString("Set", "Login", "", M_str_Name) == "1")//判断SQL登录模式的值是否为1
            {
                ckbox_Windows.Checked = false;//设置Windows身份验证复选框取消选中
                ckbox_SQL.Checked = true;//设置Sql Server身份验证复选框选中
                txt_Name.Text = ReadString("Set", "Uid", "", M_str_Name);//读取SQL登录名
                txt_Pwd.Text = ReadString("Set", "Pwd", "", M_str_Name);//读取SQL登录密码
            }
            cbox_Server.Text = ReadString("Set", "Database", "", M_str_Name);//读取数据库名
            if (ReadString("Set", "Auto", "", M_str_Name) == "0")//判断是否自动执行的值是否为0
            {
                ckbox_Auto.Checked = true;//设置是否自动执行复选框选中
                timer1.Enabled = true;//设置计时器可用
            }
            else if (ReadString("Set", "Auto", "", M_str_Name) == "1")//判断是否自动执行的值是否为1
            {
                ckbox_Auto.Checked = false;//设置是否自动执行复选框取消选中
                timer1.Enabled = false;//设置计时器不可用
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openFileDialog1.Title = "选择Excel文件";//设置打开对话框标题
            openFileDialog1.Multiselect = false;//设置打开对话框中可以多选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文本框中显示Excel文件名
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

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "Excel", txt_Path.Text, M_str_Name);//设置Excel文件路径
            WritePrivateProfileString("Set", "Server", txt_Server.Text, M_str_Name);//设置SQL服务器名
            if (ckbox_Windows.Checked)//判断Windows身份验证复选框是否选中
            {
                WritePrivateProfileString("Set", "Login", "0", M_str_Name);//设置SQL登录模式的值为0
                WritePrivateProfileString("Set", "Uid", "", M_str_Name);//设置SQL登录用户名为空
                WritePrivateProfileString("Set", "Pwd", "", M_str_Name);//设置SQL登录密码为空
            }
            else if (ckbox_SQL.Checked)//判断Sql Server身份验证复选框是否选中
            {
                WritePrivateProfileString("Set", "Login", "1", M_str_Name);//设置SQL登录模式的值为1
                WritePrivateProfileString("Set", "Uid", txt_Name.Text, M_str_Name);//设置SQL登录用户名
                WritePrivateProfileString("Set", "Pwd", txt_Pwd.Text, M_str_Name);//设置SQL登录密码
            }
            WritePrivateProfileString("Set", "Database", cbox_Server.Text, M_str_Name);//设置数据库名
            if (ckbox_Auto.Checked)//判断是否自动执行复选框是否选中
            {
                WritePrivateProfileString("Set", "Auto", "0", M_str_Name);//设置自动执行
            }
            else
            {
                WritePrivateProfileString("Set", "Auto", "1", M_str_Name);//设置不自动执行
            }
            MessageBox.Show("配置文件设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//启动计时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string P_str_Name = "";//存储遍历到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//实例化泛型集合对象，用来存储工作表名称
            P_str_Name = txt_Path.Text;//记录遍历到的Excel文件名
            P_list_SheetNames = GetSheetName(P_str_Name);//获取Excel文件中的所有工作表名
            for (int j = 0; j < P_list_SheetNames.Count; j++)//遍历所有工作表
            {
                if (ckbox_Windows.Checked)//如果用Windows身份验证登录Sql Server
                    ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Initial Catalog =" + cbox_Server.Text + ";Integrated Security=SSPI;");//将工作表内容导出到Sql Server
                else if (ckbox_SQL.Checked)//如果用Sql Server身份验证登录Sql Server
                    ImportDataToSql(P_str_Name, P_list_SheetNames[j], "Data Source=" + txt_Server.Text + ";Database=" + cbox_Server.Text + ";Uid=" + txt_Name.Text + ";Pwd=hbyt2008!@#;" + txt_Pwd.Text + ";");//将工作表内容导出到Sql Server
            }
            System.Threading.Thread.Sleep(60000);//使线程休眠1分钟
        }

        private DataTable GetTable(string P_str_Sql)//获取指定服务器中的所有数据库
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(P_str_Sql);//实例化数据库连接对象
                SqlDataAdapter sqlda = new SqlDataAdapter("select name from sysdatabases", sqlcon);//实例化数据桥接器对象
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
            CloseProcess("EXCEL");//关闭所有Excel进程
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
            CloseProcess("EXCEL");//关闭所有Excel进程
            //定义连接Excel的字符串   
            string P_str_OledbCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0;";
            OleDbConnection oledbcon = new OleDbConnection(P_str_OledbCon);//实例化Oledb数据库连接对象
            string P_str_ExcelSql = "";//定义变量，用来记录要执行的Excel查询语句
            OleDbDataAdapter oledbda = null;//实例化Oledb数据桥接器对象
            P_str_ExcelSql = string.Format("select * from [{0}$]", P_str_SheetName);//记录要执行的Excel查询语句
            oledbda = new OleDbDataAdapter(P_str_ExcelSql, P_str_OledbCon);//使用数据桥接器执行Excel查询
            oledbda.Fill(myds, P_str_SheetName);//填充数据
            string P_str_CreateSql = string.Format("use " + cbox_Server.Text + " if object_Id('" + P_str_SheetName + "') is not null drop table " + P_str_SheetName + " create table {0}(", P_str_SheetName);//定义变量，用来记录创建表的SQL语句
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

        private void CloseProcess(string P_str_Process)//关闭进程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
            System.Threading.Thread.Sleep(10);//使线程休眠10毫秒
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止计时器
        }
    }
}
