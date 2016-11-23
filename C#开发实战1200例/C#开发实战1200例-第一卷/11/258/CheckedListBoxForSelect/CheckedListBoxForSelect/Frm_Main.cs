using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace CheckedListBoxForSelect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public void GetScoure( string strSql)
        {
            string Connection = string.Format(//定义数据库连接字符串
                @"Provider=Microsoft.Jet.OLEDB.4.0;
Data Source=test.mdb;User Id=Admin");
            OleDbConnection P_Connection = //创建连接数据库对象
                new OleDbConnection(Connection);
            P_Connection.Open();//打开数据库连接
            OleDbCommand P_Command = //创建数据库命令对象
                new OleDbCommand(strSql,P_Connection);
            dataGridView1.Rows.Clear();//清空DataGridView中的数据
            OleDbDataReader P_DataReader = //得到数据读取器对象
                P_Command.ExecuteReader();
            while (P_DataReader.Read())//开始读取数据
            {
                dataGridView1.Rows.Add(P_DataReader[0].ToString(),//向DataGridView中添加数据
                    P_DataReader[1].ToString(), P_DataReader[2].ToString(),
                    P_DataReader[3].ToString(), P_DataReader[4].ToString(),
                    P_DataReader[5].ToString());
            }
            P_Connection.Close();//关闭数据库连接
        }

        private void bntEsce_Click(object sender, EventArgs e)
        {
            ckClass.Checked = false;//取消选中控件
            ckName.Checked = false;//取消选中控件
            ckId.Checked = false;//取消选中控件
            rdbMan.Checked = false;//取消选中控件
            rdbWoMan.Checked = false;//取消选中控件
        }

        private void ckId_CheckedChanged(object sender, EventArgs e)
        {
            if (ckId.Checked == true)//判断是否输入学号信息
            {
                txtstuId.Enabled = true;//允许输入学号信息
                txtstuId.Focus();//得到焦点
            }
            else
            {
                txtstuId.Text = "";//清空学号信息
                txtstuId.Enabled = false;//不允许输入学号信息
            }
        }

        private void ckClass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckClass.Checked == true)//判断是否输入班级信息
            {
                txtClass.Enabled = true;//允许输入班级信息
                txtClass.Focus();//得到焦点
            }
            else
            {
                txtClass.Text = "";//清空学号信息
                txtClass.Enabled = false;//不允许输入班级信息
             }
        }

        private void ckName_CheckedChanged(object sender, EventArgs e)
        {
            if (ckName.Checked == true)//判断是否输入姓名信息
            {
                txtName.Enabled = true;//允许输入姓名信息
                txtName.Focus();//得到焦点
            }
            else
            {
                txtName.Text = "";//清空姓名信息
                txtName.Enabled = false;//不允许输入姓名信息
            }
        }
        //
        public string strSql;//用于存储SQL语句
        public string strId;//用于存学生编号
        public string strName;//用于存储学生姓名
        public string strClass;//用于存储学生班级
        public string strSex;//用于存储学生姓别
        public static int intCount=0;//控制数据组索引
        public string[] strScoure = new string[4];//定义查询字符串数组
        public int intAdd ;//用来判断SQL语句数组数量
        private void bntSearch_Click(object sender, EventArgs e)
        {
            intCount = 0;
            if (txtstuId.Text != "")//判断输入编号是否为空
            {
                strId = "学生编号  like '%" + //定义SQL字符串
                    txtstuId.Text + "%'"  ;
                strScoure[intCount]=strId;//向字符串集合添加SQL字符串
                intCount++;//开始记数
                  
            }
            if (txtName.Text != "")
            {
                strName = "学生姓名 like '%" +//定义SQL字符串 
                    txtName.Text + "%' ";
                strScoure[intCount]= strName;//向字符串集合添加SQL字符串
                intCount++;//开始记数
            }
            if (txtClass.Text != "")
            {
                strClass = "所在年级 like '%" + //定义SQL字符串
                    txtClass.Text + "%'";
                strScoure[intCount]= strClass;//向字符串集合添加SQL字符串
                intCount++;//开始记数
            }
            if (rdbMan.Checked == true)
            {
                strSex = "学生性别 like '%" + //定义SQL字符串
                    rdbMan.Text + "%'";
                strScoure[intCount]= strSex;//向字符串集合添加SQL字符串
                intCount++;//开始记数
            }
            if (rdbWoMan.Checked==true)
            {
                strSex = "学生性别 like '%" + //定义SQL字符串
                rdbWoMan.Text + "%'";
                strScoure[intCount]= strSex;//向字符串集合添加SQL字符串
                intCount++;//开始记数
            }
            for (int i = 0; i < strScoure.Length; i++)//遍历字符串集合
            {
                if (strScoure[i] != null)//判断字符是否为空
                {
                    strSql += strScoure[i];//组合查询字符串
                    intAdd++;//开始记数
                }
            }
            switch (intAdd)//使用多路选择语句组合查询语句
            { 
   
                case 0:
                    strSql = "select * from tb_Student";
                    break;
                case 1:
                    strSql = "select * from tb_Student where " + strScoure[0];
                    break;
                case 2:
                    strSql = "select * from tb_Student where " + strScoure[0] + 
                        " and " + strScoure[1];
                    break;
                case 3:

                    strSql = "select * from tb_Student where " + strScoure[0] + 
                        " and " + strScoure[1] + " and " + strScoure[2];
                    break;   
                case 4:
                    strSql = "select * from tb_Student where " + strScoure[0] + 
                        " and " + strScoure[1] + " and " + strScoure[2] + 
                        " and " + strScoure[3];
                    break;
            }
            GetScoure(strSql);//查询数据库中数据
            intAdd = 0;//记数器置0
            intCount = 0;//记灵器置0
            strSql = "";//重置SQL语句
            for (int i = 0; i < strScoure.Length; i++)
            {
                if (strScoure[i] != null)
                {
                    strScoure[i] = null;//清空字符串数组内容
                }
            }
        }
    }
}