using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace AutoMultiExcelToOneExcel
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
            txt_MultiExcel.Text = ReadString("Set", "MultiExcel", "", M_str_Name);//读取默认的多个Excel文件
            txt_Excel.Text = ReadString("Set", "Excel", "", M_str_Name);//读取目标Excel文件
            nudown_Hour.Value = Convert.ToInt32(ReadString("Set", "Hour", "", M_str_Name));//读取小时
            nudown_Min.Value = Convert.ToInt32(ReadString("Set", "Min", "", M_str_Name));//读取分钟
            timer1.Start();//启动计时器
        }

        private void btn_SelectMultiExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMultiExcel = new OpenFileDialog();//实例化打开对话框对象
            openMultiExcel.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openMultiExcel.Multiselect = true;//设置打开对话框中可以多选
            if (openMultiExcel.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                for (int i = 0; i < openMultiExcel.FileNames.Length; i++)//遍历选择的多个文件
                    txt_MultiExcel.Text += openMultiExcel.FileNames[i] + ",";//显示选择的多个Excel文件
            }
        }

        private void btn_SelectExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();//实例化打开对话框对象
            openExcel.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openExcel.Multiselect = false;//设置打开对话框中不能多选
            if (openExcel.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Excel.Text = openExcel.FileName;//显示选择的Excel文件
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "MultiExcel", txt_MultiExcel.Text, M_str_Name);//设置多个Excel文件路径
            WritePrivateProfileString("Set", "Excel", txt_Excel.Text, M_str_Name);//设置目标Excel文件路径
            WritePrivateProfileString("Set", "Hour", nudown_Hour.Value.ToString(), M_str_Name);//设置小时
            WritePrivateProfileString("Set", "Min", nudown_Min.Value.ToString(), M_str_Name);//设置分钟
            MessageBox.Show("配置文件设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//启动计时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            string[] P_str_Names = txt_MultiExcel.Text.Split(',');//存储所有选择的Excel文件名
            string P_str_Name = "";//存储遍历到的Excel文件名
            List<string> P_list_SheetNames = new List<string>();//实例化泛型集合对象，用来存储工作表名称
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//创建新工作表
            if (DateTime.Now.Hour == nudown_Hour.Value && DateTime.Now.Minute == nudown_Min.Value)
            {
                for (int i = 0; i < P_str_Names.Length - 1; i++)//遍历所有选择的Excel文件名
                {
                    P_str_Name = P_str_Names[i];//记录遍历到的Excel文件名
                    //指定要复制的工作簿
                    Microsoft.Office.Interop.Excel.Workbook Tempworkbook = excel.Application.Workbooks.Open(P_str_Name, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                    P_list_SheetNames = GetSheetName(P_str_Name);//获取Excel文件中的所有工作表名
                    for (int j = 0; j < P_list_SheetNames.Count; j++)//遍历所有工作表
                    {
                        //指定要复制的工作表
                        Microsoft.Office.Interop.Excel.Worksheet TempWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)Tempworkbook.Sheets[P_list_SheetNames[j]];//创建新工作表
                        TempWorksheet.Copy(missing, newWorksheet);//将工作表内容复制到目标工作表中
                    }
                    Tempworkbook.Close(false, missing, missing);//关闭临时工作簿
                }
            }
            workbook.Save();//保存目标工作簿
            workbook.Close(false, missing, missing);//关闭目标工作簿
            MessageBox.Show("程序在" + DateTime.Now.ToShortTimeString() + "分时自动汇总了多个Excel文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseProcess("EXCEL");//关闭所有Excel进程
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打开选择的Excel文件
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止计时器
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

        private void CloseProcess(string P_str_Process)//关闭进程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
            System.Threading.Thread.Sleep(10);//使线程休眠10毫秒
        }
    }
}
