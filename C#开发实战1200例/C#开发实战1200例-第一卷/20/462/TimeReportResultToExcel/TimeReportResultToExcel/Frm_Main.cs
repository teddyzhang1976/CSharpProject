using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TimeReportResultToExcel
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
            txt_Floder.Text = ReadString("Set", "Floder", "", M_str_Name);//读取默认文件夹
            txt_Path.Text = ReadString("Set", "Excel", "", M_str_Name);//读取默认Excel文件
            nudown_Hour.Value = Convert.ToInt32(ReadString("Set", "Hour", "", M_str_Name));//读取小时
            nudown_Min.Value = Convert.ToInt32(ReadString("Set", "Min", "", M_str_Name));//读取分钟
            timer1.Start();//启动计时器
        }

        private void btn_SelectFlod_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FDialog=new FolderBrowserDialog();//实例化浏览文件夹对话框对象
            FDialog.RootFolder = Environment.SpecialFolder.Desktop;//设置浏览文件夹对话框的初始路径
            openFileDialog1.Multiselect = false;//设置浏览文件夹对话框中只能单选
            if (FDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                txt_Floder.Text = FDialog.SelectedPath;//在文本框中显示选择的文件夹
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openFileDialog1.Title = "选择Excel文件";//设置打开对话框标题
            openFileDialog1.Multiselect = false;//设置打开对话框中只能单选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文本框中显示Excel文件名
            }
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Set", "Floder", txt_Floder.Text, M_str_Name);//设置默认文件夹路径
            WritePrivateProfileString("Set", "Excel", txt_Path.Text, M_str_Name);//设置Excel文件路径
            WritePrivateProfileString("Set", "Hour", nudown_Hour.Value.ToString(), M_str_Name);//设置小时
            WritePrivateProfileString("Set", "Min", nudown_Min.Value.ToString(), M_str_Name);//设置分钟
            MessageBox.Show("配置文件设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();//启动计时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == nudown_Hour.Value && DateTime.Now.Minute == nudown_Min.Value)
            {
                string P_str_Floder = txt_Floder.Text;//记录文件夹路径
                string P_str_Excel = txt_Path.Text;//记录Excel文件路径
                List<string> P_list_FileNames = new List<string>();//实例化泛型集合对象，用来存储所有上报的文件
                P_list_FileNames = GetAllFile(P_str_Floder);//获取所有指定类型的文件
                for (int j = 0; j < P_list_FileNames.Count; j++)//遍历所有上报的文件
                {
                    ReadDataToExcel(P_list_FileNames[j], P_str_Excel);//将上报的文件数据处理到Excel
                }
                CloseProcess("EXCEL");//关闭所有Excel进程
                MessageBox.Show("程序在" + DateTime.Now.ToShortTimeString() + "分时自动将各地上报的结果处理到了Excel中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();//停止计时器
        }

        private List<string> GetAllFile(string P_str_Floder)//获取指定文件夹中的所有txt文件
        {
            List<string> P_list_FileNames = new List<string>();//实例化泛型集合对象，用来存储所有遍历的文件
            string [] P_str_Files = Directory.GetFiles(P_str_Floder);//获取指定文件夹中的所有文件
            for (int i = 0; i < P_str_Files.Length; i++)//遍历获取到的文件
            {
                FileInfo FInfo = new FileInfo(P_str_Files[i]);//实例化FileInfo对象
                if (FInfo.Extension.ToLower() == ".txt")//判断文件是否是txt文件
                {
                    P_list_FileNames.Add(FInfo.FullName);//将文件添加到泛型集合中
                }
            }
            return P_list_FileNames;//返回泛型集合对象
        }

        private void ReadDataToExcel(string P_str_File, string P_str_Excel)
        {
            int P_int_Count = 0;//记录正在读取的行数
            string P_str_Line;//记录读取行的内容
            List<string> P_str_List = new List<string>();//存储读取的所有内容
            StreamReader SReader = new StreamReader(P_str_File, Encoding.Default);//实例化流读取对象
            while ((P_str_Line = SReader.ReadLine()) != null)//循环读取文本文件中的每一行
            {
                P_str_List.Add(P_str_Line);//将读取到的行内容添加到泛型集合中
                P_int_Count++;//使当前读取行数加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //添加一个新的工作表
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            newWorksheet.Name = DateTime.Now.ToString("yyyyMMddhhmmss")+DateTime.Now.Millisecond;//以当前时间作为工作表名称
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            for (int i = 0; i < P_str_List.Count; i++)//遍历泛型集合
            {
                newWorksheet.Cells[i + 1, 1] = P_str_List[i];//直接将遍历到的内容添加到工作表中
            }
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
        }

        private void CloseProcess(string P_str_Process)//关闭进程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
        }
    }
}