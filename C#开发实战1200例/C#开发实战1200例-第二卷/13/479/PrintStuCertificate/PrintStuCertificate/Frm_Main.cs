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

namespace PrintStuCertificate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strCon = @"Data Source=LVSHUANG\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        public static string strName = "";
        public static string strSex = "";
        public static string strBirthday = "";
        public static string strNPlace = "";
        public static string strAddress = "";
        public static string strNation = "";
        public static string strSGao = "";
        public static string strTZhong = "";
        public static string strHunYin = "";
        public static Image imgPhoto = null;
        public static string strGZJL = "";
        public static string strBYYX = "";
        public static string strXUELLI = "";
        public static string strBYSJ = "";
        public static string strZHUANYE = "";
        public static string strWAIYU = "";
        public static string strYPZW = "";
        public static string strGZNX = "";
        public static string strQZLX = "";
        public static string strSalary = "";
        public static string strGZDQ = "";
        public static string strTECHANG = "";
        public static string strTel = "";
        public static string strEmail = "";
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet myds;
        #endregion

        //窗体初始化时，自动编号并显示所有学生信息
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlcon = getCon();
            SqlCommand sqlcmd = new SqlCommand("proc_AutoStuID", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outValue = sqlcmd.Parameters.Add("@newID", SqlDbType.VarChar, 20);
            outValue.Direction = ParameterDirection.Output;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            txtID.Text = outValue.Value.ToString();
            dgvInfo.DataSource = SelectStuInfo("", "").Tables[0];
            cboxHunYin.SelectedIndex = cboxNation.SelectedIndex = cboxQZLX.SelectedIndex = cboxSex.SelectedIndex = cboxXueLi.SelectedIndex = 0;
        }

        //选择学生头像
        private void button1_Click(object sender, EventArgs e)
        {
            //定义可选择的头像类型
            openFileDialog1.Filter = "*.jpg,*jpeg,*.bmp,*.ico,*.png,*.tif,*.wmf|*.jpg;*jpeg;*.bmp;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.Title = "选择头像";
            //判断是否选择了头像
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //显示选择的学生头像
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        //添加学生信息
        private void button2_Click(object sender, EventArgs e)
        {
            sqlcon = getCon();
            sqlcmd = new SqlCommand("proc_InsertStuInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
            sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = txtName.Text;
            sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = cboxSex.Text;
            sqlcmd.Parameters.Add("@birthday", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtBirthday.Text);
            sqlcmd.Parameters.Add("@nplace", SqlDbType.VarChar, 200).Value = txtNPlace.Text;
            sqlcmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value = txtAddress.Text;
            sqlcmd.Parameters.Add("@nation", SqlDbType.VarChar, 20).Value = cboxNation.Text;
            sqlcmd.Parameters.Add("@sgao", SqlDbType.Int).Value = Convert.ToInt32(txtShenGao.Text);
            sqlcmd.Parameters.Add("@tzhong", SqlDbType.Int).Value = Convert.ToInt32(txtTiZhong.Text);
            sqlcmd.Parameters.Add("@hunyin", SqlDbType.Char, 4).Value = cboxHunYin.Text;
            if (openFileDialog1.FileName != "")
            {
                FileStream FStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader BReader = new BinaryReader(FStream);
                byte[] byteImage = BReader.ReadBytes((int)FStream.Length);
                sqlcmd.Parameters.Add("@photo", SqlDbType.Image).Value = byteImage;
            }
            else
                sqlcmd.Parameters.Add("@photo", SqlDbType.Image).Value = null;
            sqlcmd.Parameters.Add("@gzjl", SqlDbType.Text).Value = rtxtGZJL.Text;
            sqlcmd.Parameters.Add("@byyx", SqlDbType.VarChar, 100).Value = txtBYYX.Text;
            sqlcmd.Parameters.Add("@xueli", SqlDbType.Char, 10).Value = cboxXueLi.Text;
            sqlcmd.Parameters.Add("@rxsj", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtRXSJ.Text);
            sqlcmd.Parameters.Add("@bysj", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtBYSJ.Text);
            sqlcmd.Parameters.Add("@zhuanye", SqlDbType.VarChar, 50).Value = txtZhuanYe.Text;
            sqlcmd.Parameters.Add("@waiyu", SqlDbType.VarChar, 20).Value = txtWaiYu.Text;
            sqlcmd.Parameters.Add("@ypzw", SqlDbType.VarChar, 50).Value = txtYPZW.Text;
            sqlcmd.Parameters.Add("@gznx", SqlDbType.Int).Value = Convert.ToInt32(txtGZNX.Text);
            sqlcmd.Parameters.Add("@qzlx", SqlDbType.Char, 4).Value = cboxQZLX.Text;
            sqlcmd.Parameters.Add("@salary", SqlDbType.Int).Value = Convert.ToInt32(txtSalary.Text);
            sqlcmd.Parameters.Add("@gzdq", SqlDbType.VarChar, 50).Value = txtGZDQ.Text;
            sqlcmd.Parameters.Add("@techang", SqlDbType.Text).Value = rtxtTC.Text;
            sqlcmd.Parameters.Add("@tel", SqlDbType.VarChar, 20).Value = txtTel.Text;
            sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
            SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            int int_returnValue = (int)returnValue.Value;
            if (int_returnValue == 0)
                MessageBox.Show("已经存在该学生编号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("学生信息——添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvInfo.DataSource = SelectStuInfo("", "").Tables[0];
        }

        //修改学生信息
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon = getCon();
                sqlcmd = new SqlCommand("proc_UpdateStuInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
                sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = txtName.Text;
                sqlcmd.Parameters.Add("@sex", SqlDbType.Char, 4).Value = cboxSex.Text;
                sqlcmd.Parameters.Add("@birthday", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtBirthday.Text);
                sqlcmd.Parameters.Add("@nplace", SqlDbType.VarChar, 200).Value = txtNPlace.Text;
                sqlcmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value = txtAddress.Text;
                sqlcmd.Parameters.Add("@nation", SqlDbType.VarChar, 20).Value = cboxNation.Text;
                sqlcmd.Parameters.Add("@sgao", SqlDbType.Int).Value = Convert.ToInt32(txtShenGao.Text);
                sqlcmd.Parameters.Add("@tzhong", SqlDbType.Int).Value = Convert.ToInt32(txtTiZhong.Text);
                sqlcmd.Parameters.Add("@hunyin", SqlDbType.Char, 4).Value = cboxHunYin.Text;
                FileStream FStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader BReader = new BinaryReader(FStream);
                byte[] byteImage = BReader.ReadBytes((int)FStream.Length);
                sqlcmd.Parameters.Add("@photo", SqlDbType.Image).Value = byteImage;
                sqlcmd.Parameters.Add("@gzjl", SqlDbType.Text).Value = rtxtGZJL.Text;
                sqlcmd.Parameters.Add("@byyx", SqlDbType.VarChar, 100).Value = txtBYYX.Text;
                sqlcmd.Parameters.Add("@xueli", SqlDbType.Char, 10).Value = cboxXueLi.Text;
                sqlcmd.Parameters.Add("@rxsj", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtRXSJ.Text);
                sqlcmd.Parameters.Add("@bysj", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtBYSJ.Text);
                sqlcmd.Parameters.Add("@zhuanye", SqlDbType.VarChar, 50).Value = txtZhuanYe.Text;
                sqlcmd.Parameters.Add("@waiyu", SqlDbType.VarChar, 20).Value = txtWaiYu.Text;
                sqlcmd.Parameters.Add("@ypzw", SqlDbType.VarChar, 50).Value = txtYPZW.Text;
                sqlcmd.Parameters.Add("@gznx", SqlDbType.Int).Value = Convert.ToInt32(txtGZNX.Text);
                sqlcmd.Parameters.Add("@qzlx", SqlDbType.Char, 4).Value = cboxQZLX.Text;
                sqlcmd.Parameters.Add("@salary", SqlDbType.Int).Value = Convert.ToInt32(txtSalary.Text);
                sqlcmd.Parameters.Add("@gzdq", SqlDbType.VarChar, 50).Value = txtGZDQ.Text;
                sqlcmd.Parameters.Add("@techang", SqlDbType.Text).Value = rtxtTC.Text;
                sqlcmd.Parameters.Add("@tel", SqlDbType.VarChar, 20).Value = txtTel.Text;
                sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("学生信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvInfo.DataSource = SelectStuInfo("", "").Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //删除学生信息
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon = getCon();
                sqlcmd = new SqlCommand("proc_DeleteStuInfo", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("学生信息——删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvInfo.DataSource = SelectStuInfo("", "").Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //根据学生编号显示其详细信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                myds = SelectStuInfo("编号", dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtID.Text = myds.Tables[0].Rows[0][0].ToString();
                txtName.Text = myds.Tables[0].Rows[0][1].ToString();
                cboxSex.SelectedItem = myds.Tables[0].Rows[0][2].ToString();
                mtxtBirthday.Text = myds.Tables[0].Rows[0][3].ToString();
                txtNPlace.Text = myds.Tables[0].Rows[0][4].ToString();
                txtAddress.Text = myds.Tables[0].Rows[0][5].ToString();
                cboxNation.SelectedItem = myds.Tables[0].Rows[0][6].ToString();
                txtShenGao.Text = myds.Tables[0].Rows[0][7].ToString();
                txtTiZhong.Text = myds.Tables[0].Rows[0][8].ToString();
                cboxHunYin.SelectedItem = myds.Tables[0].Rows[0][9].ToString();
                MemoryStream MStream = new MemoryStream((byte[])myds.Tables[0].Rows[0][10]);
                pictureBox1.Image = Image.FromStream(MStream);  //显示学生头像
                rtxtGZJL.Text = myds.Tables[0].Rows[0][11].ToString();
                txtBYYX.Text = myds.Tables[0].Rows[0][12].ToString();
                cboxXueLi.SelectedItem = myds.Tables[0].Rows[0][13].ToString();
                mtxtRXSJ.Text = myds.Tables[0].Rows[0][14].ToString();
                mtxtBYSJ.Text = myds.Tables[0].Rows[0][15].ToString();
                txtZhuanYe.Text = myds.Tables[0].Rows[0][16].ToString();
                txtWaiYu.Text = myds.Tables[0].Rows[0][17].ToString();
                txtYPZW.Text = myds.Tables[0].Rows[0][18].ToString();
                txtGZNX.Text = myds.Tables[0].Rows[0][19].ToString();
                cboxQZLX.SelectedItem = myds.Tables[0].Rows[0][20].ToString();
                txtSalary.Text = myds.Tables[0].Rows[0][21].ToString();
                txtGZDQ.Text = myds.Tables[0].Rows[0][22].ToString();
                rtxtTC.Text = myds.Tables[0].Rows[0][23].ToString();
                txtTel.Text = myds.Tables[0].Rows[0][24].ToString();
                txtEmail.Text = myds.Tables[0].Rows[0][25].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //打印选中的学生简历
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                myds = SelectStuInfo("编号", dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
                strName = myds.Tables[0].Rows[0][1].ToString();
                strSex = myds.Tables[0].Rows[0][2].ToString();
                strBirthday = myds.Tables[0].Rows[0][3].ToString();
                strNPlace = myds.Tables[0].Rows[0][4].ToString();
                strAddress = myds.Tables[0].Rows[0][5].ToString();
                strNation = myds.Tables[0].Rows[0][6].ToString();
                strSGao = myds.Tables[0].Rows[0][7].ToString() + "cm";
                strTZhong = myds.Tables[0].Rows[0][8].ToString() + "kg";
                strHunYin = myds.Tables[0].Rows[0][9].ToString();
                MemoryStream MStream = new MemoryStream((byte[])myds.Tables[0].Rows[0][10]);
                imgPhoto = Image.FromStream(MStream);  //记录学生头像
                strGZJL = myds.Tables[0].Rows[0][11].ToString();
                strBYYX = myds.Tables[0].Rows[0][12].ToString();
                strXUELLI = myds.Tables[0].Rows[0][13].ToString();
                strBYSJ = myds.Tables[0].Rows[0][15].ToString();
                strZHUANYE = myds.Tables[0].Rows[0][16].ToString();
                strWAIYU = myds.Tables[0].Rows[0][17].ToString();
                strYPZW = myds.Tables[0].Rows[0][18].ToString();
                strGZNX = myds.Tables[0].Rows[0][19].ToString() + "年";
                strQZLX = myds.Tables[0].Rows[0][20].ToString();
                strSalary = myds.Tables[0].Rows[0][21].ToString();
                strGZDQ = myds.Tables[0].Rows[0][22].ToString();
                strTECHANG = myds.Tables[0].Rows[0][23].ToString();
                strTel = myds.Tables[0].Rows[0][24].ToString();
                strEmail = myds.Tables[0].Rows[0][25].ToString();
                frmPrint frmprint = new frmPrint();
                frmprint.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //刷新窗体
        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
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

        #region 查询学生信息
        /// <summary>
        /// 查询学生信息
        /// </summary>
        /// <param name="str">查询条件</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataSet数据集对象</returns>
        private DataSet SelectStuInfo(string str, string strKeyWord)
        {
            sqlcon = getCon();
            sqlda = new SqlDataAdapter();
            sqlcmd = new SqlCommand("proc_SelectStuInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            switch (str)
            {
                case "编号":
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = strKeyWord;
                    break;
                default:
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = "";
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
