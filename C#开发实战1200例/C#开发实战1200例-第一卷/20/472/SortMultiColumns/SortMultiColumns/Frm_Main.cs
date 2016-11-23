using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SortMultiColumns
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void tsbtn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();//实例化打开对话框对象
            openFile.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openFile.Title = "打开Excel文件";//设置打开对话框标题
            if (openFile.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                tstxt_Excel.Text=openFile.FileName;
                WBrowser_Excel.Navigate(openFile.FileName);//在窗体中显示Excel文件内容
                List<string> P_list_SheetNames = GetSheetName(tstxt_Excel.Text);//获取选中Excel中的所有工作表
                tscbox_Sheet.Items.Clear();//清空工具栏中的下拉列表
                foreach (string P_str_SheetName in P_list_SheetNames)//遍历工作表集合
                {
                    tscbox_Sheet.Items.Add(P_str_SheetName);//将工作表名称显示在下拉列表中
                }
                if (tscbox_Sheet.Items.Count > 0)//判断下拉列表中是否有项
                    tscbox_Sheet.SelectedIndex = 0;//设置默认选择第一项
            }
        }

        private void tscbox_Sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(tstxt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//声明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[tscbox_Sheet.Text]);//获取选择的工作表
            worksheet.Activate();//激活工作表
            excel.DisplayAlerts = false;//设置保存Excel时不显示对话框
            workbook.Save();//保存工作表
            CloseProcess("EXCEL");//关闭所有Excel进程
            WBrowser_Excel.Navigate(tstxt_Excel.Text);//在窗体中重新显示Excel文件内容
        }

        private void tsbtn_ASCSort_Click(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
            string P_str_Excel = tstxt_Excel.Text;//记录Excel文件路径
            string P_str_SheetName = tscbox_Sheet.Text;//记录选择的工作表名称
            object P_obj_Start = tstxt_Start.Text;//记录开始单元格
            object P_obj_End = tstxt_End.Text;//记录结束单元格
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//声明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[P_str_SheetName]);//获取选择的工作表
            Microsoft.Office.Interop.Excel.Range searchRange = worksheet.get_Range(P_obj_Start, P_obj_End);//定义查找范围
            switch (searchRange.Columns.Count)
            {
                case 1:
                    //按1列升序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             missing, missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
                case 2:
                    //按2列升序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             searchRange.Columns[2, missing], missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
                case 3:
                default:
                    //按3列升序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             searchRange.Columns[2, missing], missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             searchRange.Columns[3, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
            }
            excel.DisplayAlerts = false;//设置保存Excel时不显示对话框
            workbook.Save();//保存工作表
            CloseProcess("EXCEL");//关闭所有Excel进程
            WBrowser_Excel.Navigate(P_str_Excel);//在窗体中重新显示Excel文件内容
        }

        private void tsbtn_DESCSort_Click(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
            string P_str_Excel = tstxt_Excel.Text;//记录Excel文件路径
            string P_str_SheetName = tscbox_Sheet.Text;//记录选择的工作表名称
            object P_obj_Start = tstxt_Start.Text;//记录开始单元格
            object P_obj_End = tstxt_End.Text;//记录结束单元格
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//声明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[P_str_SheetName]);//获取选择的工作表
            Microsoft.Office.Interop.Excel.Range searchRange = worksheet.get_Range(P_obj_Start, P_obj_End);//定义查找范围
            switch (searchRange.Columns.Count)
            {
                case 1:
                    //按1列降序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             missing, missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
                case 2:
                    //按2列降序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             searchRange.Columns[2, missing], missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
                case 3:
                default:
                    //按3列降序排序
                    searchRange.Sort(
             searchRange.Columns[1, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             searchRange.Columns[2, missing], missing, Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             searchRange.Columns[3, missing], Microsoft.Office.Interop.Excel.XlSortOrder.xlDescending,
             Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo, missing, missing,
             Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
             Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
             Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
                    break;
            }
            excel.DisplayAlerts = false;//设置保存Excel时不显示对话框
            workbook.Save();//保存工作表
            CloseProcess("EXCEL");//关闭所有Excel进程
            WBrowser_Excel.Navigate(P_str_Excel);//在窗体中重新显示Excel文件内容
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
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
        }
    }
}