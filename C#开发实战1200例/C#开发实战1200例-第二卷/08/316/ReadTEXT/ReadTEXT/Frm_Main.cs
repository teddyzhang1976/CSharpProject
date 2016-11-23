using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.OleDb;

namespace ReadTEXT
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_open = new OpenFileDialog();//创建打开文件对话框对象
            P_open.Filter = "文本文件|*.txt|所有文件|*.*";//设置筛选字符串
            if (P_open.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = P_open.FileName;//显示文件路径
                string conn = string.Format(//创建连接字符串
                     @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=text",
                     P_open.FileName.Substring(0,P_open.FileName.LastIndexOf(@"\")));
                OleDbConnection P_OleDbConnection = new OleDbConnection(conn);//创建连接对象
                try
                {
                    P_OleDbConnection.Open();//打开连接
                    OleDbCommand cmd = new OleDbCommand(//创建命令对象
                        string.Format("select * from {0}",
                        P_open.FileName.Substring(P_open.FileName.LastIndexOf(@"\"),
                        P_open.FileName.Length - P_open.FileName.LastIndexOf(@"\"))),
                        P_OleDbConnection);
                    OleDbDataReader oda = cmd.ExecuteReader();//得到数据读取器对象
                    while (oda.Read())
                    {
                       txt_Message.Text  += oda[0].ToString();//得到文本文件中的字符串
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//弹出消息对话框
                }
                finally
                {
                    P_OleDbConnection.Close();//关闭连接
                }
            }
        }

        class Employee//员工类
        {
            public string Id { get; set; }//Id属性
            public string Name { get; set; }//姓名属性
            public string Age { get; set; }//年龄属性
        }
    }
}
