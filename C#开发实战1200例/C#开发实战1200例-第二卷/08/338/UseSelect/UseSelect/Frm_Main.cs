using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace UseSelect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义公共对象及变量
        SqlConnection sqlcon;
        SqlDataAdapter sqlda;
        DataSet myds;
        string strCon = @"Data Source =LVSHUANG\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        string strSql = "select ID as 职工编号,Name as 职工姓名,Sex as 性别,Age as 年龄,Tel as 联系电话,Address as 家庭地址,QQ as QQ号码,Email as Email地址 from tb_Employee";
        public static string FindValue = "";  //存储查询条件
        #endregion

        //窗体初始化时显示所有职工信息
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllInfo(strSql);
            cbox_Sex.SelectedIndex = 0;
        }

        //综合查询职工信息
        private void btnQuery_Click(object sender, EventArgs e)
        {
            FindValue = "";//得到空字符串对象
            string Find_SQL = strSql;//得到SQL字符串对象
            if (FindValue.Length > 0)
                FindValue = FindValue + "and";//组合SQL字符串
            if (txt_id.Text != "")
                FindValue += "(ID='" + txt_id.Text + "') and";//组合SQL字符串
            if (txt_Name.Text != "")
                FindValue += "(Name='" + txt_Name.Text + "') and";//组合SQL字符串
            if (cbox_Sex.Text != "")
                FindValue += "(Sex='" + cbox_Sex.Text + "') and";//组合SQL字符串
            if (txt_Age.Text != "" && txt_Age2.Text != "")
            {
                if (validateNum(txt_Age.Text) && validateNum(txt_Age2.Text))
                    FindValue += "(Age between " + Convert.ToInt32(txt_Age.Text) +//组合SQL字符串
                        " and " + Convert.ToInt32(txt_Age2.Text) + ") and";
                else
                {
                    MessageBox.Show("年龄必须为数字！");//弹出消息对话框
                    txt_Age.Text = txt_Age2.Text = "";//引用空字符串
                    txt_Age.Focus();//得到焦点
                }
            }
            else
            {
                if (txt_Age.Text != "")
                {
                    if (validateNum(txt_Age.Text))
                        FindValue += "(Age = " + Convert.ToInt32(txt_Age.Text) + ") and";//组合SQL字符串
                    else
                    {
                        MessageBox.Show("年龄必须为数字！");//弹出消息对话框
                        txt_Age.Text = "";//引用空字符串
                        txt_Age.Focus();//得到焦点
                    }
                }
                else if (txt_Age2.Text != "")
                {
                    if (validateNum(txt_Age2.Text))
                        FindValue += "(Age = " + Convert.ToInt32(txt_Age2.Text) + ") and";//组合SQL字符串
                    else
                    {
                        MessageBox.Show("年龄必须为数字！");//弹出消息对话框
                        txt_Age2.Text = "";//引用空字符串
                        txt_Age2.Focus();//得到焦点
                    }
                }
            }
            if (txt_QQ.Text != "")
            {
                if (validateNum(txt_QQ.Text) && txt_QQ.Text.Length >= 4 && txt_QQ.Text.Length <= 9)
                    FindValue += "(QQ =" + Convert.ToInt32(txt_QQ.Text) + ") and";//组合SQL字符串
                else
                {
                    MessageBox.Show("QQ号码必须为4到9位以内的数字！");//弹出消息对话框
                    txt_QQ.Text = "";//引用空字符串
                    txt_QQ.Focus();//得到焦点
                }
            }
            if (txt_Phone.Text != "")
            {
                if (validatePhone(txt_Phone.Text))
                    FindValue += "(Tel='" + txt_Phone.Text + "') and";//组合SQL字符串
                else
                {
                    MessageBox.Show("请输入正确的电话号码！");//弹出消息对话框
                    txt_Phone.Text = "";//引用空字符串
                    txt_Phone.Focus();//得到焦点
                }
            }
            if (txt_Email.Text != "")
            {
                if (validateEmail(txt_Email.Text))
                    FindValue += "(Email='" + txt_Email.Text + "') and";//组合SQL字符串
                else
                {
                    MessageBox.Show("请输入正确的Email地址！");//弹出消息对话框
                    txt_Email.Text = "";//引用空字符串
                    txt_Email.Focus();//得到焦点
                }
            }
            if (txt_Address.Text != "")
                FindValue += "(Address='" + txt_Address.Text + "') and";//组合SQL字符串
            if (FindValue.Length > 0)
            {
                if (FindValue.IndexOf("and") > -1)
                    FindValue = FindValue.Substring(0, FindValue.Length - 4);//删除AND运算符
            }
            else
                FindValue = "";
            if (FindValue != "")   //如果FindValue字段不为空
                Find_SQL = Find_SQL + " where " + FindValue;//组合SQL字符串
            GetAllInfo(Find_SQL);//按照SQL字符串进行查询
        }

        //清空文本框
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox1.Controls)
            {
                if (ctl.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    ctl.Text = "";
                }
            }
            txt_id.Focus();
            cbox_Sex.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labCount.Text = "共有" + (txt_Message.Rows.Count - 1) + "条记录";
        }

        #region 根据条件查询职工信息
        /// <summary>
        /// 根据条件查询职工信息
        /// </summary>
        /// <param name="strsql">设置查询条件的SQL语句</param>
        private void GetAllInfo(string strsql)
        {
            sqlcon = new SqlConnection(strCon);
            sqlda = new SqlDataAdapter(strsql, sqlcon);
            myds = new DataSet();
            sqlda.Fill(myds);
            txt_Message.DataSource = myds.Tables[0];
        }
        #endregion

        #region  验证输入为数字
        /// <summary>
        /// 验证输入为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool validateNum(string str)
        {
            return Regex.IsMatch(str, "^[0-9]*[1-9][0-9]*$");
        }
        #endregion

        #region  验证输入为电话号码
        /// <summary>
        /// 验证输入为电话号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool validatePhone(string str)
        {
            return Regex.IsMatch(str, @"^(\d{3,4})-(\d{7,8})$");
        }
        #endregion

        #region  验证输入为Email
        /// <summary>
        /// 验证输入为Email
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool validateEmail(string str)
        {
            return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        #endregion
    }
}
