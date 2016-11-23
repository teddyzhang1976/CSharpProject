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

namespace ExcelToTxt
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

        private void btn_Txt_Click(object sender, EventArgs e)
        {
            //连接Excel数据库
            OleDbConnection olecon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Path.Text + ";Extended Properties=Excel 8.0");
            olecon.Open();//打开数据库连接
            OleDbDataAdapter oledbda = new OleDbDataAdapter("select * from [" + cbox_SheetName.Text + "$]", olecon);//从工作表中查询数据
            DataSet myds = new DataSet();//实例化数据集对象
            oledbda.Fill(myds);//填充数据集
            StreamWriter SWriter = new StreamWriter(cbox_SheetName.Text + ".txt", false, Encoding.Default);//实例化写入流对象
            string P_str_Content = "";//存储读取的内容
            for (int i = 0; i < myds.Tables[0].Rows.Count; i++)//遍历数据集中表的行数
            {
                for (int j = 0; j < myds.Tables[0].Columns.Count; j++)//遍历数据集中表的列数
                {
                    P_str_Content += myds.Tables[0].Rows[i][j].ToString() + "  ";//记录当前遍历到的内容
                }
                P_str_Content += Environment.NewLine;//字符串换行
            }
            SWriter.Write(P_str_Content);//先文本文件中写入内容
            SWriter.Close();//关闭写入流对象
            SWriter.Dispose();//释放写入流所占用的资源
            MessageBox.Show("已经将" + cbox_SheetName.Text + "工作表中的数据成功写入到了文本文件中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
