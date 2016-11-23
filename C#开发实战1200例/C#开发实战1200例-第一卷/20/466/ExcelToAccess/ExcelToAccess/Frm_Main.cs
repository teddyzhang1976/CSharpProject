using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ExcelToAccess
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
            openFileDialog1.Multiselect = false;//设置打开对话框中只能单选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Path.Text = openFileDialog1.FileName;//在文本框中显示Excel文件名
                CBoxBind();//对下拉列表进行数据绑定
            }
        }

        private void btn_Access_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Access文件|*.mdb";//设置打开文件筛选器
            openFileDialog1.Title = "选择Access文件";//设置打开对话框标题
            openFileDialog1.Multiselect = false;//设置打开对话框中只能单选
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Access.Text = openFileDialog1.FileName;//在文本框中显示Access文件名
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//声明object缺省值
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet;//声明工作表
            Microsoft.Office.Interop.Access.Application access = new Microsoft.Office.Interop.Access.Application();//实例化Access对象
            worksheet = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[cbox_SheetName.Text]);//获取选择的工作表
            worksheet.Move(workbook.Sheets[1], missing);//将选择的工作表作为第一个工作表
            object P_obj_Name = (object)worksheet.Name;//获取工作表名称
            excel.DisplayAlerts = false;//设置Excel保存时不显示对话框
            workbook.Save();//保存工作簿
            CloseProcess("EXCEL");//关闭所有Excel进程
            object P_obj_Excel = (object)txt_Path.Text;//记录Excel文件路径
            try
            {
                access.OpenCurrentDatabase(txt_Access.Text, true, "");//打开Access数据库
                //将Excel指定工作表中的数据导入到Access中
                access.DoCmd.TransferSpreadsheet(Microsoft.Office.Interop.Access.AcDataTransferType.acImport, Microsoft.Office.Interop.Access.AcSpreadSheetType.acSpreadsheetTypeExcel97, P_obj_Name, P_obj_Excel, true, missing, missing);
                access.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveAll);//关闭并保存Access数据库文件
                CloseProcess("MSACCESS");//关闭所有Access数据库进程
                MessageBox.Show("已经将Excel的" + cbox_SheetName.Text + "工作表中的数据导入到Access数据库中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Access数据库中已经存在该表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Access.Text);//打开导出后的Access文件
        }

        private void CBoxBind()//对下拉列表进行数据绑定
        {
            cbox_SheetName.Items.Clear();//清空下拉列表项
            //连接Excel数据库
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            olecon.Open();//打开数据库连接
            System.Data.DataTable DTable = olecon.GetSchema("Tables");//实例化表对象
            DataTableReader DTReader = new DataTableReader(DTable);//实例化表读取对象
            while (DTReader.Read())//循环读取
            {
                string P_str_Name = DTReader["Table_Name"].ToString().Replace('$', ' ').Trim();//记录工作表名称
                if (!cbox_SheetName.Items.Contains(P_str_Name))//判断下拉列表中是否已经存在该工作表名称
                    cbox_SheetName.Items.Add(P_str_Name);//将工作表名添加到下拉列表中
            }
            DTable = null;//清空表对象
            DTReader = null;//清空表读取对象
            olecon.Close();//关闭数据库连接
            cbox_SheetName.SelectedIndex = 0;//设置下拉列表默认选项为第一项
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
