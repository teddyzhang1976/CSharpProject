using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiWordToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_SelectWord_Click(object sender, EventArgs e)
        {
            txt_Word.Text = "";//清空文本框
            OpenFileDialog openWord = new OpenFileDialog();//实例化打开对话框对象
            openWord.Filter = "Word文件|*.doc;*.docx";//设置打开文件筛选器
            openWord.Multiselect = true;//设置打开对话框中可以多选
            if (openWord.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                for (int i = 0; i < openWord.FileNames.Length; i++)//遍历选择的多个文件
                    txt_Word.Text += openWord.FileNames[i] + ",";//显示选择的Word文件
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

        private void btn_Read_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//实例化Word对象
            Microsoft.Office.Interop.Word.Table table;//声明Word表格对象
            int P_int_TableCount = 0, P_int_Row = 0, P_int_Column = 0;//定义3个变量，分别用来存储表格数量、表格中的行数、列数
            string P_str_Content;//存储Word表格的单元格内容
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            string[] P_str_Names = txt_Word.Text.Split(',');//存储所有选择的Word文件名
            object P_obj_Name;//存储遍历到的Word文件名
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//创建新工作表
            for (int i = 0; i < P_str_Names.Length - 1; i++)//遍历所有选择Word文件名
            {
                P_obj_Name = P_str_Names[i];//记录遍历到的Word文件名
                //打开Word文档
                Microsoft.Office.Interop.Word.Document document = word.Documents.Open(ref P_obj_Name, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                P_int_TableCount = document.Tables.Count;//获取Word文档中表格的数量
                if (P_int_TableCount > 0)//判断表格数量是否大于0
                {
                    for (int j = 1; j <= P_int_TableCount; j++)//遍历所有表格
                    {
                        table = document.Tables[j];//记录遍历到的表格
                        P_int_Row = table.Rows.Count;//获取表格行数
                        P_int_Column = table.Columns.Count;//获取表格列数
                        for (int row = 1; row <= P_int_Row; row++)//遍历表格中的行
                        {
                            for (int column = 1; column <= P_int_Column; column++)//遍历表格中的列
                            {
                                P_str_Content = table.Cell(row, column).Range.Text;//获取遍历到的单元格内容
                                newWorksheet.Cells[i + row, column] = P_str_Content.Substring(0, P_str_Content.Length - 2);//将遍历到的单元格内容添加到Excel单元格中
                            }
                        }
                    }
                }
                else
                {
                    if (P_int_Row == 0)//判断前面是否已经填充过表格
                        newWorksheet.Cells[i + P_int_Row + 1, 1] = document.Content.Text;//直接将Word文档内容添加到工作表中
                    else
                        newWorksheet.Cells[i + P_int_Row, 1] = document.Content.Text;//直接将Word文档内容添加到工作表中
                }
                document.Close(ref missing, ref missing, ref missing);//关闭Word文档
            }
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
            word.Quit(ref missing, ref missing, ref missing);//退出Word应用程序
            MessageBox.Show("已经成功将多个Word文档的内容合并到了Excel的同一个数据表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打开选择的Excel文件
        }
    }
}
