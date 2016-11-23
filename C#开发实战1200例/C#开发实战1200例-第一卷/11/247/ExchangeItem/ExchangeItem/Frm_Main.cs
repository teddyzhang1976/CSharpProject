using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ExchangeItem
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public void AddList()//添加数据
        {
            string P_Connection = string.Format(//创建数据库连接字符串
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_OLEDBConnection = //创建连接对象
                new OleDbConnection(P_Connection);
            P_OLEDBConnection.Open();//连接到数据库
            OleDbCommand P_OLEDBCommand = new OleDbCommand(//创建命令对象
                "select * from [message]",
                P_OLEDBConnection);
            OleDbDataReader P_Reader = //得到数据读取器
                P_OLEDBCommand.ExecuteReader();
            while (P_Reader.Read())//读取数据
            {
                lb_Source.Items.Add(P_Reader[0]);//将数据放入集合
            }
        }

        private void button2_Click(object sender, EventArgs e)//全部添加到选择的项中
        {
            for (int i = 0; i < lb_Source.Items.Count; i++)
            {
                lb_Source.SelectedIndex = i;//按索引选中项
                lb_Choose.Items.Add(//添加新项
                    lb_Source.SelectedItem.ToString());
            }
            lb_Source.Items.Clear();//清空项
        }

        private void button3_Click(object sender, EventArgs e)//全部添加到数据源中
        {
            for (int i = 0; i < lb_Choose.Items.Count; i++)
            {
                lb_Choose.SelectedIndex = i;//按索引选中项
                lb_Source.Items.Add(//添加项
                    lb_Choose.SelectedItem.ToString());
            }
            lb_Choose.Items.Clear();//清空项
        }
        private void frmListBox_Load(object sender, EventArgs e)
        {
            AddList();//向控件中添加数据
        }

        private void button1_Click(object sender, EventArgs e)//单个添加到选择的项中
        {
            if (lb_Source.SelectedIndex != -1)
            {
                this.lb_Choose.Items.Add(//添加项
                    this.lb_Source.SelectedItem.ToString());
                this.lb_Source.Items.Remove(//移除项
                    this.lb_Source.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)//单个添加到数据源中
        {
            if (lb_Choose.SelectedIndex != -1)
            {
                this.lb_Source.Items.Add(//添加项
                    this.lb_Choose.SelectedItem.ToString());
                this.lb_Choose.Items.Remove(//移除项
                    this.lb_Choose.SelectedItem);
            }
        }
    }
}