using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditByProc
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet myds;
        #endregion

        //自动生成编号，并对DataGridView控件进行数据绑定
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvInfo.DataSource = SelectEInfo("","").Tables[0];
        }

        //在DataGridView控件中选择用户时，将其信息显示在相应的文本框中
        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                myds = SelectEInfo("职工编号", dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtID.Text = myds.Tables[0].Rows[0][0].ToString();
                txtName.Text = myds.Tables[0].Rows[0][1].ToString();
                cboxSex.SelectedItem = myds.Tables[0].Rows[0][2].ToString();
                txtAge.Text = myds.Tables[0].Rows[0][3].ToString();
                txtTel.Text = myds.Tables[0].Rows[0][4].ToString();
                txtAddress.Text = myds.Tables[0].Rows[0][5].ToString();
                txtQQ.Text = myds.Tables[0].Rows[0][6].ToString();
                txtEmail.Text = myds.Tables[0].Rows[0][7].ToString();
            }
            catch { }
        }

        //修改职工信息
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon = getCon();
                sqlcmd = new SqlCommand("proc_UpdateEInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
                sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = txtName.Text;
                sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = cboxSex.Text;
                sqlcmd.Parameters.Add("@age", SqlDbType.Int).Value = Convert.ToInt32(txtAge.Text);
                sqlcmd.Parameters.Add("@tel", SqlDbType.VarChar, 20).Value = txtTel.Text;
                sqlcmd.Parameters.Add("@address", SqlDbType.VarChar, 100).Value = txtAddress.Text;
                sqlcmd.Parameters.Add("@qq", SqlDbType.BigInt).Value = Convert.ToInt32(txtQQ.Text);
                sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("职工信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvInfo.DataSource = SelectEInfo("", "").Tables[0];
            }
            catch { }
        }

        #region 获得数据库连接
        /// <summary>
        /// 获得数据库连接
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        private SqlConnection getCon()
        {
            sqlcon = new SqlConnection(strCon);
            sqlcon.Open();
            return sqlcon;
        }
        #endregion

        #region 查询职工信息
        /// <summary>
        /// 查询职工信息
        /// </summary>
        /// <param name="str">查询条件</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataSet数据集对象</returns>
        private DataSet SelectEInfo(string str,string strKeyWord)
        {
            sqlcon = getCon();
            sqlda = new SqlDataAdapter();
            sqlcmd = new SqlCommand("proc_SelectEInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            switch (str)
            {
                case "职工编号":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = strKeyWord;
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
                case "职工姓名":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = strKeyWord;
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
                case "性别":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = strKeyWord;
                    break;
                default:
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
                    sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "";
                    sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = "";
                    break;
            }
            sqlda.SelectCommand = sqlcmd;
            myds = new DataSet();
            sqlda.Fill(myds);
            sqlcon.Close();
            return myds;
        }
        #endregion
    }
}
