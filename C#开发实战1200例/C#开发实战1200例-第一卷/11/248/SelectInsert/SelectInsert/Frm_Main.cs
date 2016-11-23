using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SelectInsert
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string P_Connection = string.Format(//创建数据库连接字符串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //创建连接对象
                new OleDbConnection(P_Connection);
            try
            {
                P_OLEDBConnection.Open();//连接到数据库
                OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                    "select * from [message]",
                    P_OLEDBConnection);
                OleDbDataReader P_Reader = //得到数据读取器
                    P_OLEDBCommand.ExecuteReader();
                while (P_Reader.Read())//读取数据
                {
                    lb_str.Items.Add(P_Reader[0]);//将数据放入集合
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据读取失败！\r\n" + ex.Message, "错误！");
            }
            finally
            {
                P_OLEDBConnection.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_str.SelectedItem.ToString() != null)
            {
                txt_Name.Text = lb_str.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lb_str.SelectedItem.ToString() != null)
            {
                txt_Name.Text = lb_str.SelectedItem.ToString();
            }
        }

        private void btn_Buy_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(txt_Name.Text+" 购买成功！","提示！");
        }

    }
}