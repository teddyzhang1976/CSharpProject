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

        public void AccessGuideJoinExcel(string Access, string AccTable, string Excel)
        {
            try
            {
                string tem_sql = "";//定义字符串
                string connstr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Access + ";Persist Security Info=True";//记录连接Access的语句
                System.Data.OleDb.OleDbConnection tem_conn = new System.Data.OleDb.OleDbConnection(connstr);//连接Access数据库
                System.Data.OleDb.OleDbCommand tem_comm;//定义OleDbCommand类
                tem_conn.Open();//打开连接的Access数据库
                tem_sql = "select Count(*) From " + AccTable;//设置SQL语句，获取记录个数
                tem_comm = new System.Data.OleDb.OleDbCommand(tem_sql, tem_conn);//实例化OleDbCommand类
                int RecordCount = (int)tem_comm.ExecuteScalar();//执行SQL语句，并返回结果
                //每个Sheet只能最多保存65536条记录。
                tem_sql = @"select top 65535 * into [Excel 8.0;database=" + Excel + @".xls].[Sheet2] from 帐目";//记录连接Excel的语句
                tem_comm = new System.Data.OleDb.OleDbCommand(tem_sql, tem_conn);//实例化OleDbCommand类
                tem_comm.ExecuteNonQuery();//执行SQL语句，将数据表的内容导入到Excel中
                tem_conn.Close();//关闭连接
                tem_conn.Dispose();//释放资源
                tem_conn = null;
                MessageBox.Show("导入完成");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"提示！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccessGuideJoinExcel(textBox1.Text, comboBox1.Text, textBox2.Text + "\\" + textBox3.Text);
        }

        public void GetTable(string Apath, ComboBox ComBox)
        {
            string connstr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Apath + ";Persist Security Info=True";
            System.Data.OleDb.OleDbConnection tem_OleConn = new System.Data.OleDb.OleDbConnection(connstr);
            tem_OleConn.Open();
            DataTable tem_DataTable = tem_OleConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            tem_OleConn.Close();
            ComBox.Items.Clear();
            for (int i = 0; i < tem_DataTable.Rows.Count; i++)
            {
                ComBox.Items.Add(tem_DataTable.Rows[i][2]);
            }
            if (ComBox.Items.Count > 0)
                ComBox.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                GetTable(textBox1.Text, comboBox1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
