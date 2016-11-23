using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TxtToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_SelectTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTxt = new OpenFileDialog();//实例化打开对话框对象
            openTxt.Filter = "文本文件|*.txt";//设置打开文件筛选器
            openTxt.Multiselect = false;//设置打开对话框中不能多选
            if (openTxt.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Txt.Text = openTxt.FileName;//显示选择的文本文件
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
            int P_int_Count=0;//记录正在读取的行数
            string P_str_Line, P_str_Content = "";//记录读取行的内容及遍历到的内容
            List<string> P_str_List = new List<string>();//存储读取的所有内容
            StreamReader SReader = new StreamReader(txt_Txt.Text, Encoding.Default);//实例化流读取对象
            while ((P_str_Line = SReader.ReadLine()) != null)//循环读取文本文件中的每一行
            {
                P_str_List.Add(P_str_Line);//将读取到的行内容添加到泛型集合中
                P_int_Count++;//使当前读取行数加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(txt_Excel.Text, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            for (int i = 0; i < P_str_List.Count; i++)//遍历泛型集合
            {
                P_str_Content = P_str_List[i];//记录遍历到的值
                if (Regex.IsMatch(P_str_Content, "^[0-9]*[1-9][0-9]*$"))//判断是否是数字
                    newWorksheet.Cells[i + 1, 1] = Convert.ToDecimal(P_str_Content).ToString("￥00.00");//格式化为货币格式，再添加到工作表中
                else
                    newWorksheet.Cells[i + 1, 1] = P_str_Content;//直接将遍历到的内容添加到工作表中
            }
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
            MessageBox.Show("已经将文本文件内容成功导入Excel工作表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打开选择的Excel文件
        }
    }
}
