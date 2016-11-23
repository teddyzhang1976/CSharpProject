using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MultiExcelToWord
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private object P_obj_WordName = "";//记录Word文件路径及名称
        private void btn_SelectExcel_Click(object sender, EventArgs e)
        {
            txt_Excel.Text = "";//清空文本框
            OpenFileDialog openExcel = new OpenFileDialog();//实例化打开对话框对象
            openExcel.Filter = "Excel文件|*.xls";//设置打开文件筛选器
            openExcel.Multiselect = true;//设置打开对话框中不能多选
            if (openExcel.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                for (int i = 0; i < openExcel.FileNames.Length; i++)//遍历选择的多个文件
                    txt_Excel.Text += openExcel.FileNames[i] + ",";//显示选择的Excel文件
            }
        }

        private void btn_SelectTxt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog=new FolderBrowserDialog();//实例化浏览文件夹对话框对象
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                txt_Word.Text = FBDialog.SelectedPath;//显示选择的Word存放路径
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
            string[] P_str_Names = txt_Excel.Text.Split(',');//存储所有选择的Excel文件名
            object P_obj_Name;//存储遍历到的Excel文件名
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();//实例化Word对象
            if (txt_Word.Text.EndsWith("\\"))//判断路径是否以\结尾
                P_obj_WordName = txt_Word.Text + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//记录Word文件路径及名称
            else
                P_obj_WordName = txt_Word.Text + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//记录Word文件路径及名称
            Microsoft.Office.Interop.Word.Table table;//声明Word表格对象
            Microsoft.Office.Interop.Word.Document document = new Microsoft.Office.Interop.Word.Document();//声明Word文档对象
            document = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);//新建Word文档
            Microsoft.Office.Interop.Word.Range range ;//声明范围对象
            int P_int_Rows = 0, P_int_Columns = 0;//存储工作表中数据的行数和列数
            object P_obj_start = 0, P_obj_end = 0;//分别记录创建表格的开始和结束范围                   
            object P_obj_Range = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd;//定义要合并的范围位置
            for (int i = 0; i < P_str_Names.Length - 1; i++)//遍历所有选择的Excel文件名
            {
                P_obj_Name = P_str_Names[i];//记录遍历到的Excel文件名
                List<string> P_list_SheetName = CBoxBind(P_obj_Name.ToString());//获取指定Excel中的所有工作表
                for (int j = 0; j < P_list_SheetName.Count; j++)//遍历所有工作表
                {
                    range = document.Range(ref missing, ref missing);//获取Word范围
                    range.InsertAfter(P_obj_Name + "——" + P_list_SheetName[j] + "工作表");//插入文本
                    range.Font.Name = "宋体";//设置字体
                    range.Font.Size = 10;//设置字体大小
                    DataSet myds = CBoxShowCount(P_obj_Name.ToString(), P_list_SheetName[j]);//获取工作表中的所有数据
                    P_int_Rows = myds.Tables[0].Rows.Count;//记录工作表的行数
                    P_int_Columns = myds.Tables[0].Columns.Count;//记录工作表的列数
                    range.Collapse(ref P_obj_Range);//合并范围
                    if (P_int_Rows > 0 && P_int_Columns > 0)//判断如果工作表中有记录
                    {
                        //在指定范围处添加一个指定行数和列数的表格
                        table = range.Tables.Add(range, P_int_Rows, P_int_Columns, ref missing, ref missing);
                        for (int r = 0; r < P_int_Rows; r++)//遍历行
                        {
                            for (int c = 0; c < P_int_Columns; c++)//遍历列
                            {
                                table.Cell(r + 1, c + 1).Range.InsertAfter(myds.Tables[0].Rows[r][c].ToString());//将遍历到的数据添加到Word表格中
                            }
                        }
                    }
                    object P_obj_Format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;//定义Word文档的保存格式
                    word.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;//设置保存时不显示对话框
                    //保存Word文档
                    document.SaveAs(ref P_obj_WordName, ref P_obj_Format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                }
            }
            document.Close(ref missing, ref missing, ref missing);//关闭Word文档
            word.Quit(ref missing, ref missing, ref missing);//退出Word应用程序
            MessageBox.Show("已经成功将多个Excel文件的内容读取到了一个Word文档中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(P_obj_WordName.ToString());//打开生成的Word文件
        }

        //获取指定Excel中的所有工作表
        private List<string> CBoxBind(string P_str_Excel)
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
                {
                    P_list_SheetName.Add(P_str_Name);//将工作表名添加到泛型集合中
                }
            }
            DTable = null;//清空表对象
            DTReader = null;//清空表读取对象
            olecon.Close();//关闭数据库连接
            return P_list_SheetName;//返回泛型集合
        }

        //获取Excel工作表中的数据
        private DataSet CBoxShowCount(string P_str_Excel,string P_str_Name)
        {
            //连接Excel数据库
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + P_str_Excel + ";Extended Properties=Excel 8.0");
            OleDbDataAdapter oledbda = new OleDbDataAdapter("select * from [" + P_str_Name + "$]", olecon);//从工作表中查询数据
            DataSet myds = new DataSet();//实例化数据集对象
            oledbda.Fill(myds);//填充数据集
            return myds;//返回数据集
        }
    }
}
