using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CreateExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了路径
            {
                txt_Path.Text = folderBrowserDialog1.SelectedPath;//显示选择的路径
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string P_str_path = txt_Path.Text;//记录路径
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            Microsoft.Office.Interop.Excel.Workbook newWorkBook = excel.Application.Workbooks.Add(true);//添加新工作簿
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            newWorkBook.Worksheets.Add(missing, missing, missing, missing);//向Excel文件中增加工作表
            if (P_str_path.EndsWith("\\"))//判断路径是否\结尾
                newWorkBook.SaveCopyAs(P_str_path + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");//保存Excel文件
            else
                newWorkBook.SaveCopyAs(P_str_path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");//保存Excel文件
            MessageBox.Show("Excel文件创建成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出提示信息
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
        }
    }
}
