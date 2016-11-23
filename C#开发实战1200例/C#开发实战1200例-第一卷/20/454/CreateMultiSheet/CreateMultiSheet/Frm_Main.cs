using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace CreateMultiSheet
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string M_str_Name = "";
        private void 打开Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter="Excel文件|*.xls";//设置打开文件筛选器
            OpenFileDialog.Title = "打开Excel文件";//设置打开对话框标题
            OpenFileDialog.Multiselect = false;//设置打开对话框中不能多选
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                M_str_Name = OpenFileDialog.FileName;//记录选择的Excel文件
                WBrowser_Excel.Navigate(M_str_Name);//在窗体中显示Excel文件内容
            }
        }

        private void 创建工作表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProcess();//关闭Excel进程
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            object missing = Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(M_str_Name, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, 1, missing);
            MessageBox.Show("添加工作表成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
            WBrowser_Excel.Navigate(M_str_Name);//在窗体中显示Excel文件内容
        }

        private void CloseProcess()
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
            System.Threading.Thread.Sleep(10);//使线程休眠10毫秒
        }
    }
}
