using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;

namespace DeleteSheet
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            object missing = Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Path.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[cbox_SheetName.Text]).Delete();//删除选择的工作表
            MessageBox.Show("工作表删除成功！");
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            CBoxBind();//对下拉列表进行数据绑定
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
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
                cbox_SheetName.Items.Add(DTReader["Table_Name"].ToString().Replace('$',' ').Trim());//将工作表名添加到下拉列表中
            }
            DTable = null;//清空表对象
            DTReader = null;//清空表读取对象
            olecon.Close();//关闭数据库连接
            cbox_SheetName.SelectedIndex = 0;//设置下拉列表默认选项为第一项
        }
    }
}
