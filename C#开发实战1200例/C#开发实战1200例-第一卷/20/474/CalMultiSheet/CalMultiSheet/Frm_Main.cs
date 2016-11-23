using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CalMultiSheet
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
            openFile.Title = "打开Excel模板";//设置打开对话框标题
            openFile.InitialDirectory = Application.StartupPath;//设置初始路径
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

        private void tsbtn_Calc_Click(object sender, EventArgs e)
        {
            int P_int_Start = 0;//定义开始计算的行
            int P_int_End = 0;//定义结束计算的行
            P_int_Start = Convert.ToInt32(tstxt_Start.Text);//记录开始计算行
            P_int_End = Convert.ToInt32(tstxt_End.Text);//记录结束计算行
            for (int i = P_int_Start; i <= P_int_End; i++)//遍历所有要计算的行
            {
                CalcData(i, tstxt_Column.Text);//多表计算，并将计算结果写入Excel中
            }
            MessageBox.Show("多表计算完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CalcData(int P_int_Row, string P_str_Column)
        {
            CloseProcess("EXCEL");//关闭所有Excel进程
            string P_str_workBook1 = Application.StartupPath + "\\Excel1.xls";//记录第一个要计算的工作簿路径
            string P_str_workBook2 = Application.StartupPath + "\\Excel2.xls";//记录第二个要计算的工作簿路径
            string P_str_workBook3 = Application.StartupPath + "\\Excel3.xls";//记录第三个要计算的工作簿路径
            string P_str_workBook4 = Application.StartupPath + "\\Sum.xls";//记录存储计算结果的工作簿路径
            object missing = System.Reflection.Missing.Value;//定义object缺省值
            Microsoft.Office.Interop.Excel.ApplicationClass excel1 = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            excel1.Visible = false;//设置Excel文件隐藏
            //打开第一个计算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook1 = excel1.Workbooks.Open(P_str_workBook1, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //记录要计算的第一个工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet1 = (Microsoft.Office.Interop.Excel._Worksheet)workbook1.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel2 = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            excel2.Visible = false;//设置Excel文件隐藏
            //打开第二个计算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook2 = excel2.Workbooks.Open(P_str_workBook2, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //记录要计算的第二个工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet2 = (Microsoft.Office.Interop.Excel._Worksheet)workbook2.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel3 = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            excel3.Visible = false;//设置Excel文件隐藏
            //打开第三个计算的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook3 = excel3.Workbooks.Open(P_str_workBook3, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //记录要计算的第三个工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet3 = (Microsoft.Office.Interop.Excel._Worksheet)workbook3.Worksheets.get_Item(tscbox_Sheet.Text);
            Microsoft.Office.Interop.Excel.ApplicationClass excel4 = new Microsoft.Office.Interop.Excel.ApplicationClass();//实例化Excel对象
            excel4.Visible = false;//设置Excel文件隐藏
            //打开存储计算结果的工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook4 = excel4.Workbooks.Open(P_str_workBook4, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //记录要存储结算结果的工作表
            Microsoft.Office.Interop.Excel._Worksheet worksheet4 = (Microsoft.Office.Interop.Excel._Worksheet)workbook4.Worksheets.get_Item(tscbox_Sheet.Text);
            excel4.DisplayAlerts = false;//设置保存Excel时不显示对话框
            worksheet4.Activate();//激活工作表
            Decimal P_dml_NumOne = 0;//获取第一个工作表的值
            Decimal P_dml_NumTwo = 0;//获取第二个工作表的值
            Decimal P_dml_NumThree = 0;//获取第三个工作表的值
            //判断指定单元格内容是否为空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumOne = 0;//将第一个值设置为0
            }
            else
            {
                P_dml_NumOne = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet1.Cells[P_int_Row, P_str_Column]).Text);//记录第一个值
            }
            //判断指定单元格内容是否为空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumTwo = 0;//将第二个值设置为0
            }
            else
            {
                P_dml_NumTwo = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[P_int_Row, P_str_Column]).Text);//记录第二个值
            }
            //判断指定单元格内容是否为空
            if (((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text.ToString() == "" || ((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text == null)
            {
                P_dml_NumThree = 0;//将第三个值设置为0
            }
            else
            {
                P_dml_NumThree = Convert.ToDecimal(((Microsoft.Office.Interop.Excel.Range)worksheet3.Cells[P_int_Row, P_str_Column]).Text);//记录第三个值
            }
            Decimal P_dml_Sum = P_dml_NumOne + P_dml_NumTwo + P_dml_NumThree;//计算总和
            try
            {
                worksheet4.Cells[P_int_Row, P_str_Column] = P_dml_Sum.ToString();//向工作簿的指定单元格中写入计算后的数据
                workbook4.Save();//保存Excel文件
            }
            catch
            {
                MessageBox.Show("写入第" + P_int_Row.ToString() + "行，第" + P_str_Column + "列时出错！");
            }
            finally
            {
                workbook4.Save();//保存Excel文件
                //退出打开的4个Excel文件
                excel1.Quit();
                excel2.Quit();
                excel3.Quit();
                excel4.Quit();
            }
            WBrowser_Excel.Navigate(P_str_workBook4);//在窗体中显示多表计算后的Excel文件
        }

        private void CloseProcess(string P_str_Process)//关闭进程
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName(P_str_Process);//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
        }
    }
}