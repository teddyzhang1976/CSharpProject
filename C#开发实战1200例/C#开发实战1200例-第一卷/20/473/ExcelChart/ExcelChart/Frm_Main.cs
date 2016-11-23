using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ExcelChart
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

        private void tsbtn_Build_Click(object sender, EventArgs e)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(tstxt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//声明工作表
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[tscbox_Sheet.Text]);//获取选择的工作表
            Microsoft.Office.Interop.Excel.Range searchRange = worksheet.get_Range("A1", "E1");//定义标题范围
            object[] P_obj_Items = { "编程词典", "VC编程词典", "JAVA编程词典", "ASP.NET编程词典", "C#编程词典" };
            searchRange.set_Value(missing, P_obj_Items);//绘制标题
            searchRange.Font.Bold = true;//设置字体加粗
            searchRange.Font.Name = "宋体";//设置字体样式
            searchRange.Font.Size = 10;//设置字体大小
            searchRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//设置标题对齐方式
            //获得要生成图表的数据
            for (int i = 0; i < 13; i++)
            {
                worksheet.Cells[2 + i, 1] = i;
                worksheet.Cells[2 + i, 2] = i + 1;
                worksheet.Cells[2 + i, 3] = i + 2;
                worksheet.Cells[2 + i, 4] = i + 3;
                worksheet.Cells[2 + i, 5] = i + 4;
            }
            //实例化Excel绘图对象
            Microsoft.Office.Interop.Excel.Chart chart = (Microsoft.Office.Interop.Excel.Chart)workbook.Charts.Add(missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Range chartRange = worksheet.get_Range("A1:A14", "B1:E14");//定义绘制图表范围
            //在指定范围绘制图表
            chart.ChartWizard(chartRange, Microsoft.Office.Interop.Excel.XlChartType.xl3DColumn, missing, Microsoft.Office.Interop.Excel.XlRowCol.xlColumns, 1, 1, true, "编程词典销量分析", "月份", "销量", missing);
            excel.DisplayAlerts = false;//设置保存Excel时不显示对话框
            workbook.Save();//保存工作簿
            workbook.Close(false, missing, missing);//关闭工作簿
            CloseProcess("EXCEL");//关闭所有Excel进程
            WBrowser_Excel.Navigate(tstxt_Excel.Text);//在窗体中重新显示Excel文件内容
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