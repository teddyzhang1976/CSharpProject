using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessToExcel
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
            openTxt.Filter = "Access数据库文件|*.mdb";//设置打开文件筛选器
            openTxt.Multiselect = false;//设置打开对话框中不能多选
            if (openTxt.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                txt_Access.Text = openTxt.FileName;//显示选择的Access文件
                string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Access.Text + ";Persist Security Info=True";//记录连接Access的语句
                OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//实例化OLEDB连接对象
                oledbcon.Open();//打开数据库连接
                DataTable DTable = oledbcon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });//获取所有数据表信息
                oledbcon.Close();//关闭数据库连接
                cbox_Table.Items.Clear();//清空下拉列表
                for (int i = 0; i < DTable.Rows.Count; i++)//遍历数据表信息
                {
                    cbox_Table.Items.Add(DTable.Rows[i][2]);//将数据表名称添加到下拉列表中
                }
                if (cbox_Table.Items.Count > 0)//判断下拉列表中是否有项
                    cbox_Table.SelectedIndex = 0;//设置下拉列表默认选择第一项
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
            try
            {
                string P_str_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_Access.Text + ";Persist Security Info=True";//记录连接Access的语句
                string P_str_Sql = "";//存储要执行的SQL语句
                OleDbConnection oledbcon = new OleDbConnection(P_str_Con);//实例化OLEDB连接对象
                OleDbCommand oledbcom;//定义OleDbCommand对象
                oledbcon.Open();//打开数据库连接
                //向Excel工作表中导入数据
                P_str_Sql = @"select * into [Excel 8.0;database=" + txt_Excel.Text + "]." + "[" + cbox_Table.Text + "] from " + cbox_Table.Text + "";//记录连接Excel的语句
                oledbcom = new System.Data.OleDb.OleDbCommand(P_str_Sql, oledbcon);//实例化OleDbCommand对象
                oledbcom.ExecuteNonQuery();//执行SQL语句，将数据表的内容导入到Excel中
                oledbcon.Close();//关闭数据库连接
                oledbcon.Dispose();//释放资源
                MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(cbox_Table.Text + "工作表已经存在，请选择其他数据表！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Excel.Text);//打开选择的Excel文件
        }
    }
}
