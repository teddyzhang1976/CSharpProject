using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace EditByView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义公共的类对象及变量
        SqlConnection sqlcon;       //声明数据库连接对象
        SqlDataAdapter sqlda;       //声明数据桥接器对象
        DataSet myds;               //声明数据集对象
        //定义数据库连接字符串
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cboxSex.SelectedIndex = 0;
            ShowInfo();
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //记录选择的职工编号
            string strID = dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (strID != "")
            {
                sqlcon = new SqlConnection(strCon);     //创建数据库连接对象
                //创建数据桥接器对象
                sqlda = new SqlDataAdapter("select * from V_Info where ID='" + strID + "'", sqlcon);
                myds = new DataSet();                   //创建数据集对象
                sqlda.Fill(myds);                       //填充数据集
                //显示职工编号
                txtID.Text = myds.Tables[0].Rows[0][0].ToString();
                //显示职工姓名
                txtName.Text = myds.Tables[0].Rows[0][1].ToString();
                //显示职工性别
                cboxSex.Text = myds.Tables[0].Rows[0][2].ToString();
                //显示职工年龄
                txtAge.Text = myds.Tables[0].Rows[0][3].ToString();
                //显示职工电话
                txtTel.Text = myds.Tables[0].Rows[0][4].ToString();
                //显示职工家庭地址
                txtAddress.Text = myds.Tables[0].Rows[0][5].ToString();
                //显示职工QQ
                txtQQ.Text = myds.Tables[0].Rows[0][6].ToString();
                //显示职工Email
                txtEmail.Text = myds.Tables[0].Rows[0][7].ToString();
                //使用数据库中存储的二进制头像实例化内存数据流
                MemoryStream MStream = new MemoryStream((byte[])myds.Tables[0].Rows[0][8]);
                pictureBox1.Image = Image.FromStream(MStream);  //显示职工头像
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                //修改职工信息
                if (UpdateInfo(txtID.Text, txtName.Text, cboxSex.Text, Convert.ToInt32(txtAge.Text), txtTel.Text, txtAddress.Text, Convert.ToInt32(txtQQ.Text), txtEmail.Text))
                {
                    MessageBox.Show("通过视图修改职工信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ShowInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox1.Controls)
            {
                if (ctl.GetType().Name == "TextBox")
                    ctl.Text = "";
            }
            txtID.Focus();
        }

        #region 修改职工信息
        /// <summary>
        /// 修改职工信息
        /// </summary>
        /// <param name="strID">职工编号</param>
        /// <param name="strName">职工姓名</param>
        /// <param name="strSex">性别</param>
        /// <param name="intAge">年龄</param>
        /// <param name="strTel">电话</param>
        /// <param name="strAddress">家庭地址</param>
        /// <param name="intqq">QQ</param>
        /// <param name="strEmail">Email</param>
        /// <returns>执行成功，返回true</returns>
        private bool UpdateInfo(string strID,string strName,string strSex,int intAge,string strTel,string strAddress,int intqq,string strEmail)
        {
            sqlcon = new SqlConnection(strCon);
            SqlCommand sqlcmd = new SqlCommand("update V_Info set Name=@name,Sex=@sex,Age=@age,Tel=@tel,Address=@address,QQ=@qq,Email=@email where ID=@id", sqlcon);
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = strID;
            sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = strName;
            sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = strSex;
            sqlcmd.Parameters.Add("@age", SqlDbType.Int, 4).Value = intAge;
            sqlcmd.Parameters.Add("@tel", SqlDbType.VarChar, 20).Value = strTel;
            sqlcmd.Parameters.Add("@address", SqlDbType.VarChar, 100).Value = strAddress;
            sqlcmd.Parameters.Add("@qq", SqlDbType.BigInt, 8).Value = intqq;
            sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = strEmail;
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }
        #endregion

        #region 在DataGridView中显示职工基本信息
        /// <summary>
        /// 在DataGridView中显示职工基本信息
        /// </summary>
        private void ShowInfo()
        {
            sqlcon = new SqlConnection(strCon);
            sqlda = new SqlDataAdapter("select ID as 职工编号,Name as 职工姓名,Sex as 性别,Age as 年龄,Tel as 联系电话,Address as 家庭地址,QQ as QQ号码,Email as Email地址 from V_Info", sqlcon);
            myds = new DataSet();
            sqlda.Fill(myds);
            dgvInfo.DataSource = myds.Tables[0];
        }
        #endregion
    }
}
