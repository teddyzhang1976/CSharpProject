using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintTable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strCon = @"Data Source=LVSHUANG\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        public static string strID = "";
        public static string strInPeople = "";
        public static string strInProvider = "";
        public static string strPlace = "";
        public static string strGID = "";
        public static string strGName = "";
        public static string strGSpec = "";
        public static string strGUnit = "";
        public static string strGMoney = "";
        public static string strGNum = "";
        public static string strSMoney = "";
        public static string strInDate = "";
        public static string strRemark = "";
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlda;
        DataSet myds;
        #endregion

        //窗体初始化时显示所有入库信息
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlcon = getCon();
            SqlCommand sqlcmd = new SqlCommand("proc_AutoIGID", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter outValue = sqlcmd.Parameters.Add("@newID", SqlDbType.VarChar, 20);
            outValue.Direction = ParameterDirection.Output;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            txtID.Text = outValue.Value.ToString();
            dgvInfo.DataSource = SelectIGInfo("", "").Tables[0];
            cboxGUnit.SelectedIndex = 0;
        }

        #region 计算总金额
        private void txtGMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGNum.Text != "")
                    txtSMoney.Text = (Convert.ToDecimal(txtGMoney.Text) * Convert.ToInt32(txtGNum.Text)).ToString();
            }
            catch { }
        }

        private void txtGNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGMoney.Text != "")
                    txtSMoney.Text = (Convert.ToDecimal(txtGMoney.Text) * Convert.ToInt32(txtGNum.Text)).ToString();
            }
            catch { }
        }
        #endregion

        //根据选中的入库单显示其详细信息
        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                myds = SelectIGInfo("编号", dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtID.Text = myds.Tables[0].Rows[0][0].ToString();
                txtInPeople.Text = myds.Tables[0].Rows[0][1].ToString();
                txtInProvider.Text = myds.Tables[0].Rows[0][2].ToString();
                txtPlace.Text = myds.Tables[0].Rows[0][3].ToString();
                txtGID.Text = myds.Tables[0].Rows[0][4].ToString();
                txtGName.Text = myds.Tables[0].Rows[0][5].ToString();
                txtGSpec.Text = myds.Tables[0].Rows[0][6].ToString();
                cboxGUnit.SelectedItem = myds.Tables[0].Rows[0][7].ToString();
                txtGMoney.Text = myds.Tables[0].Rows[0][8].ToString();
                txtGNum.Text = myds.Tables[0].Rows[0][9].ToString();
                txtSMoney.Text = myds.Tables[0].Rows[0][10].ToString();
                mtxtInDate.Text = myds.Tables[0].Rows[0][11].ToString();
                txtRemark.Text = myds.Tables[0].Rows[0][12].ToString();
                strID = txtID.Text;
                strInPeople = txtInPeople.Text;
                strInProvider = txtInProvider.Text;
                strPlace = txtPlace.Text;
                strGID = txtGID.Text;
                strGName = txtGName.Text;
                strGSpec = txtGSpec.Text;
                strGUnit = myds.Tables[0].Rows[0][7].ToString();
                strGMoney = "￥" + txtGMoney.Text;
                strGNum = txtGNum.Text;
                strSMoney = "￥" + txtSMoney.Text;
                strInDate = mtxtInDate.Text;
                strRemark = txtRemark.Text;
            }
            catch { }
        }

        //添加入库信息
        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlcon = getCon();
            sqlcmd = new SqlCommand("proc_InsertIGInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
            sqlcmd.Parameters.Add("@inpeople", SqlDbType.VarChar, 20).Value = txtInPeople.Text;
            sqlcmd.Parameters.Add("@inprovider", SqlDbType.VarChar, 50).Value = txtInProvider.Text;
            sqlcmd.Parameters.Add("@place", SqlDbType.VarChar, 50).Value = txtPlace.Text;
            sqlcmd.Parameters.Add("@gid", SqlDbType.VarChar, 20).Value = txtGID.Text;
            sqlcmd.Parameters.Add("@gname", SqlDbType.VarChar, 50).Value = txtGName.Text;
            sqlcmd.Parameters.Add("@gspec", SqlDbType.VarChar, 50).Value = txtGSpec.Text;
            sqlcmd.Parameters.Add("@gunit", SqlDbType.Char, 4).Value = cboxGUnit.Text;
            sqlcmd.Parameters.Add("@gmoney", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(txtGMoney.Text);
            sqlcmd.Parameters.Add("@gnum", SqlDbType.Int).Value = Convert.ToInt32(txtGNum.Text);
            sqlcmd.Parameters.Add("@smoney", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(txtSMoney.Text);
            sqlcmd.Parameters.Add("@indate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtInDate.Text);
            sqlcmd.Parameters.Add("@remark", SqlDbType.Text).Value = txtRemark.Text;
            SqlParameter returnValue = sqlcmd.Parameters.Add("@returnValue", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            int int_returnValue = (int)returnValue.Value;
            if (int_returnValue == 0)
                MessageBox.Show("已经存在该入库编号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("商品入库信息——添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvInfo.DataSource = SelectIGInfo("", "").Tables[0];
        }
        
        //修改入库信息
        private void btnEdit_Click(object sender, EventArgs e)
        {
            sqlcon = getCon();
            sqlcmd = new SqlCommand("proc_UpdateIGInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
            sqlcmd.Parameters.Add("@inpeople", SqlDbType.VarChar, 20).Value = txtInPeople.Text;
            sqlcmd.Parameters.Add("@inprovider", SqlDbType.VarChar, 50).Value = txtInProvider.Text;
            sqlcmd.Parameters.Add("@place", SqlDbType.VarChar, 50).Value = txtPlace.Text;
            sqlcmd.Parameters.Add("@gid", SqlDbType.VarChar, 20).Value = txtGID.Text;
            sqlcmd.Parameters.Add("@gname", SqlDbType.VarChar, 50).Value = txtGName.Text;
            sqlcmd.Parameters.Add("@gspec", SqlDbType.VarChar, 50).Value = txtGSpec.Text;
            sqlcmd.Parameters.Add("@gunit", SqlDbType.Char, 4).Value = cboxGUnit.Text;
            sqlcmd.Parameters.Add("@gmoney", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(txtGMoney.Text);
            sqlcmd.Parameters.Add("@gnum", SqlDbType.Int).Value = Convert.ToInt32(txtGNum.Text);
            sqlcmd.Parameters.Add("@smoney", SqlDbType.Decimal, 9).Value = Convert.ToDecimal(txtSMoney.Text);
            sqlcmd.Parameters.Add("@indate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(mtxtInDate.Text);
            sqlcmd.Parameters.Add("@remark", SqlDbType.Text).Value = txtRemark.Text;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("商品入库信息——修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvInfo.DataSource = SelectIGInfo("", "").Tables[0];
        }

        //删除入库信息
        private void btnDel_Click(object sender, EventArgs e)
        {
            sqlcon = getCon();
            sqlcmd = new SqlCommand("proc_DeleteIGInfo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = txtID.Text;
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("商品入库信息——删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvInfo.DataSource = SelectIGInfo("", "").Tables[0];
        }

        //刷新窗体
        private void btnReflush_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        //设置打印的商品入库单据
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int printWidth = e.PageBounds.Width;//页面宽度
            int printHeight = e.PageBounds.Height;//页面高度
            int left = printWidth / 2 - 305;
            int right = printWidth / 2 + 305;
            int top = printHeight / 2-200;
            Brush myBrush = new SolidBrush(Color.Black);//创建Brush对象
            Pen mypen = new Pen(Color.Black);//创建Pen对象
            Font myFont = new Font("宋体", 12);//创建Font对象
            e.Graphics.DrawString("商品入库单", new Font("宋体", 20, FontStyle.Bold),//绘制标题
                myBrush, new Point(printWidth / 2 - 100, top));
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 300, top + 30, 480, top + 30);//绘制线条
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 300, top + 34, 480, top + 34);//绘制线条
            e.Graphics.DrawString("吉林省明日科技有限公司", new Font("宋体", 9),
                myBrush, new Point(left + 2, top + 25));
            e.Graphics.DrawString("日期：" + DateTime.Now.ToLongDateString(),
                new Font("宋体", 12), myBrush, new Point(right - 190, top + 25));
            e.Graphics.DrawRectangle(mypen, left, top + 42, 610, 230);//绘制矩形框
            e.Graphics.DrawLine(mypen, left, top + 72, left + 610, top + 72);//绘制第一行网格线
            e.Graphics.DrawLine(mypen, left, top + 102, left + 610, top + 102);//绘制第二行网格线
            e.Graphics.DrawLine(mypen, left, top + 132, left + 610, top + 132);//绘制第三行网格线
            e.Graphics.DrawLine(mypen, left, top + 162, left + 610, top + 162);//绘制第四行网格线
            e.Graphics.DrawLine(mypen, left + 80, top + 42, left + 80, top + 272);//绘制第一列网格线
            e.Graphics.DrawLine(mypen, left + 220, top + 42, left + 220, top + 72);//绘制第二列网格线
            e.Graphics.DrawLine(mypen, left + 280, top + 42, left + 280, top + 72);//绘制第三列网格线
            e.Graphics.DrawLine(mypen, left + 410, top + 42, left + 410, top + 132);//绘制第四列网格线
            e.Graphics.DrawLine(mypen, left + 470, top + 42, left + 470, top + 162);//绘制第五列网格线
            e.Graphics.DrawLine(mypen, left + 170, top + 102, left + 170, top + 162);//绘制第三行第二列网格线
            e.Graphics.DrawLine(mypen, left + 220, top + 102, left + 220, top + 162);//绘制第三行第三列网格线
            e.Graphics.DrawLine(mypen, left + 300, top + 132, left + 300, top + 162);//绘制第四行第四列网格线
            e.Graphics.DrawLine(mypen, left + 360, top + 132, left + 360, top + 162);//绘制第四行第五列网格线
            e.Graphics.DrawLine(mypen, left + 520, top + 132, left + 520, top + 162);//绘制第四行第七列网格线
            //绘制第一行数据
            e.Graphics.DrawString("入库日期", myFont, myBrush, new Point(left + 2, top + 50));
            e.Graphics.DrawString(strInDate, myFont, myBrush, new Point(left + 82, top + 50));
            e.Graphics.DrawString("单据号", myFont, myBrush, new Point(left + 222, top + 50));
            e.Graphics.DrawString(strID, myFont, myBrush, new Point(left + 282, top + 50));
            e.Graphics.DrawString("入库人", myFont, myBrush, new Point(left + 412, top + 50));
            e.Graphics.DrawString(strInPeople, myFont, myBrush, new Point(left + 472, top + 50));
            //绘制绘制第二行数据
            e.Graphics.DrawString("供货商", myFont, myBrush, new Point(left + 2, top + 80));
            e.Graphics.DrawString(strInProvider, myFont, myBrush, new Point(left + 82, top + 80));
            e.Graphics.DrawString("产地", myFont, myBrush, new Point(left + 412, top + 80));
            e.Graphics.DrawString(strPlace, myFont, myBrush, new Point(left + 472, top + 80));
            //第三行数据
            e.Graphics.DrawString("商品编号", myFont, myBrush, new Point(left + 2, top + 110));
            e.Graphics.DrawString(strGID, myFont, myBrush, new Point(left + 82, top + 110));
            e.Graphics.DrawString("名称", myFont, myBrush, new Point(left + 172, top + 110));
            e.Graphics.DrawString(strGName, myFont, myBrush, new Point(left + 222, top + 110));
            e.Graphics.DrawString("规格", myFont, myBrush, new Point(left + 412, top + 110));
            e.Graphics.DrawString(strGSpec, myFont, myBrush, new Point(left + 472, top + 110));
            //绘制第四行数据
            e.Graphics.DrawString("单位", myFont, myBrush, new Point(left + 2, top + 140));
            e.Graphics.DrawString(strGUnit, myFont, myBrush, new Point(left + 82, top + 140));
            e.Graphics.DrawString("单价", myFont, myBrush, new Point(left + 172, top + 140));
            e.Graphics.DrawString(strGMoney, myFont, myBrush, new Point(left + 222, top + 140));
            e.Graphics.DrawString("数量", myFont, myBrush, new Point(left + 302, top + 140));
            e.Graphics.DrawString(strGNum, myFont, myBrush, new Point(left + 362, top + 140));
            e.Graphics.DrawString("金额", myFont, myBrush, new Point(left + 472, top + 140));
            e.Graphics.DrawString(strSMoney, myFont, myBrush, new Point(left + 522, top + 140));
            //绘制第五行数据
            e.Graphics.DrawString("备注", myFont, myBrush, new Point(left + 2, top + 170));
            e.Graphics.DrawString(strRemark, myFont, myBrush, new Point(left + 82, top + 170));
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

        #region 查询商品入库信息
        /// <summary>
        /// 查询商品入库信息
        /// </summary>
        /// <param name="str">查询条件</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataSet数据集对象</returns>
        private DataSet SelectIGInfo(string str, string strKeyWord)
        {
            sqlcon = getCon();
            sqlda = new SqlDataAdapter();
            sqlcmd = new SqlCommand("proc_SelectIGInfo", sqlcon);
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
