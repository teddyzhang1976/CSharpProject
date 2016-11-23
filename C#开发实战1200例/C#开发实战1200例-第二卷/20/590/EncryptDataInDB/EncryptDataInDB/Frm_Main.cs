using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EncryptDataInDB
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string strID, strName;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            GetData(dataGridView1);//对dataGridView1控件进行数据绑定
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (strID != "" && strName != "")
            {
                SqlConnection sqlcon = new SqlConnection("Data Source=LVSHUANG\\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");//创建数据库连接对象
                SqlCommand sqlcom = new SqlCommand("declare @id int,@name varchar(20) select @id=" + strID + ",@name='" + strName
                    + "' insert into tb_Business(ID,BusinessName) select @id,convert(varbinary(256),pwdencrypt(@name)) "
                    + "select * from tb_Business where ID=@id and pwdcompare(@name,BusinessName)=1 delete from tb_Business where ID=" 
                    + strID + " and BusinessName='" + strName + "'", sqlcon);//创建SqlCommand对象
                sqlcon.Open();//打开数据库连接
                sqlcom.ExecuteNonQuery();//执行数据库命令
                sqlcon.Close();//关闭数据库连接
                MessageBox.Show("已成功对数据库中的数据进行了加密！");
            }
            GetData(dataGridView2);//对dataGridView2控件进行数据绑定
        }

        private void GetData(DataGridView dgv)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=LVSHUANG\\SHJ;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");//创建数据库连接对象
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from tb_Business", sqlcon);//从指定表中查找数据
            DataSet myds = new DataSet();//创建数据集对象
            sqlda.Fill(myds);//填充数据集
            dgv.DataSource = myds.Tables[0];//对数据表格控件进行数据绑定
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//记录选中的ID
            strName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();//记录选中的名称
        }
    }
}
