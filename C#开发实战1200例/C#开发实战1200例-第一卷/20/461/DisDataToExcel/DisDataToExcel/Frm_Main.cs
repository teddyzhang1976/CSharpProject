using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace DisDataToExcel
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

        private void btn_SelectWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog openWord = new OpenFileDialog();//实例化打开对话框对象
            openWord.Filter = "Word文件|*.doc;*.docx";//设置打开文件筛选器
            openWord.Multiselect = true;//设置打开对话框中可以多选
            if (openWord.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                    txt_Word.Text = openWord.FileName;//显示选择的Word文件
            }
        }

        private void btn_SelectAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog openAccess = new OpenFileDialog();//实例化打开对话框对象
            openAccess.Filter = "Access数据库文件|*.mdb";//设置打开文件筛选器
            openAccess.Multiselect = false;//设置打开对话框中不能多选
            if (openAccess.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Access.Text = openAccess.FileName;//显示选择的Access文件
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

        private void btn_Start_Click(object sender, EventArgs e)
        {
            timer1.Start();//开始计时器
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();//停止计时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_Excel.Text != "")//判断是否选择了Excel文件
            {
                if (txt_Txt.Text != "")//判断是否选择了文本文件
                    TxtToExcel(txt_Txt.Text, txt_Excel.Text);//将文本文件数据导入Excel
                if (txt_Word.Text != "")//判断是否选择了Word文件
                    WordToExcel(txt_Word.Text, txt_Excel.Text);//将Word文件数据导入Excel
                if (txt_Access.Text != "")//判断是否选择了Access文件
                {
                    List<string> P_list_Tables = GetTable(txt_Access.Text);//获取Access中的所有表
                    for (int i = 0; i < P_list_Tables.Count; i++)//遍历所有表
                    {
                        AccessToExcel(txt_Access.Text, P_list_Tables[i], txt_Excel.Text);//将表中的数据导入Excel
                    }
                }
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打开选择的Excel文件
        }

        private void TxtToExcel(string P_str_Txt,string P_str_Excel)
        {
            int P_int_Count = 0;//记录正在读取的行数
            string P_str_Line;//记录读取行的内容
            List<string> P_str_List = new List<string>();//存储读取的所有内容
            StreamReader SReader = new StreamReader(P_str_Txt, Encoding.Default);//实例化流读取对象
            while ((P_str_Line = SReader.ReadLine()) != null)//循环读取文本文件中的每一行
            {
                P_str_List.Add(P_str_Line);//将读取到的行内容添加到泛型集合中
                P_int_Count++;//使当前读取行数加1
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            for (int i = 0; i < P_str_List.Count; i++)//遍历泛型集合
            {
                newWorksheet.Cells[i + 1, 1] = P_str_List[i];//直接将遍历到的内容添加到工作表中
            }
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
        }

        private void WordToExcel(string P_str_Word, string P_str_Excel)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//实例化Word对象
            Microsoft.Office.Interop.Word.Table table;//声明Word表格对象
            int P_int_TableCount = 0, P_int_Row = 0, P_int_Column = 0;//定义3个变量，分别用来存储表格数量、表格中的行数、列数
            string P_str_Content;//存储Word表格的单元格内容
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            object P_obj_Name;//存储遍历到的Word文件名
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            //打开指定的Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(P_str_Excel, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet newWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);//创建新工作表
            P_obj_Name = (object)P_str_Word;//记录遍历到的Word文件名
            //打开Word文档
            Microsoft.Office.Interop.Word.Document document = word.Documents.Open(ref P_obj_Name, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            word.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone; ;//设置操作Word时不显示任何对话框
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
                            newWorksheet.Cells[row, column] = P_str_Content.Substring(0, P_str_Content.Length - 2);//将遍历到的单元格内容添加到Excel单元格中
                        }
                    }
                }
            }
            else
            {
                if (P_int_Row == 0)//判断前面是否已经填充过表格
                    newWorksheet.Cells[P_int_Row + 1, 1] = document.Content.Text;//直接将Word文档内容添加到工作表中
                else
                    newWorksheet.Cells[P_int_Row, 1] = document.Content.Text;//直接将Word文档内容添加到工作表中
            }
            document.Close(ref missing, ref missing, ref missing);//关闭Word文档
            excel.Application.DisplayAlerts = false;//不显示提示对话框
            workbook.Save();//保存工作表
            workbook.Close(false, missing, missing);//关闭工作表
            word.Quit(ref missing, ref missing, ref missing);//退出Word应用程序
        }

        private List<string> GetTable(string P_str_Access)
        {
            string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Access + ";Persist Security Info=True";//记录连接Access的语句
            OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//实例化OLEDB连接对象
            oledbcon.Open();//打开数据库连接
            DataTable DTable = oledbcon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });//获取所有数据表信息
            oledbcon.Close();//关闭数据库连接
            List<string> P_list_Tables = new List<string>();
            for (int i = 0; i < DTable.Rows.Count; i++)//遍历数据表信息
            {
                P_list_Tables.Add(DTable.Rows[i][2].ToString());//将数据表名称添加到泛型集合中
            }
            return P_list_Tables;
        }

        private void AccessToExcel(string P_str_Access,string P_str_Table,string P_str_Excel)
        {
            string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Access + ";Persist Security Info=True";//记录连接Access的语句
            string P_str_Sql = "";//存储要执行的SQL语句
            OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//实例化OLEDB连接对象
            OleDbCommand oledbcom;//定义OleDbCommand对象
            oledbcon.Open();//打开数据库连接
            //向Excel工作表中导入数据
            P_str_Sql = @"select * into [Excel 8.0;database=" + P_str_Excel + "]." + "[" + P_str_Table + "] from " + P_str_Table + "";//记录连接Excel的语句
            oledbcom = new System.Data.OleDb.OleDbCommand(P_str_Sql, oledbcon);//实例化OleDbCommand对象
            oledbcom.ExecuteNonQuery();//执行SQL语句，将数据表的内容导入到Excel中
            oledbcon.Close();//关闭数据库连接
            oledbcon.Dispose();//释放资源
        }
    }
}
