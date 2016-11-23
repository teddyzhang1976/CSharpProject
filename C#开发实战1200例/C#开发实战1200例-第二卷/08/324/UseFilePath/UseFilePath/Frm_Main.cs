using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseFilePath
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(//定义数据库连接字段
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");
        string strPath = "";//定义文件路径字段

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string[] strSex = { "男", "女" };//创建字符串数组
            this.comboBox1.DataSource = strSex;//设置数据源
            string[] strCall =//创建字符串数组
            { "员工", "主干人员", "部门经理", "经理" };
            this.comboBox2.DataSource = strCall;//设置数据源
            string[] strHunYin =//创建字符串数组
            { "以婚", "未婚", "离异" };
            this.comboBox3.DataSource = strHunYin;//设置数据源
            string[] strJianKang =//创建字符串数组
            { "很好", "良好", "一般" };
            this.comboBox4.DataSource = strJianKang;//设置数据源
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.openFileImage.ShowDialog();//显示图片并得到路径
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextInfo())
            {
                if (insertInfo())
                {
                    MessageBox.Show("添加成功");//弹出消息对话框
                    clearText();//清空TextBox控件文本内容
                }
            }
            else
            {
                MessageBox.Show("请输入正确信息");//弹出消息对话框
            }
        }

        private void clearText()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";//清空控件文本内容
                }
            }
            pictureBox1.Image = null;//取消显示图片
        }

        private Boolean TextInfo()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")//判断内容是否为空
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void openFileImage_FileOk(object sender, CancelEventArgs e)
        {
            strPath = this.openFileImage.FileName;//得到图像文件路径
            this.pictureBox1.Image = Image.FromFile(strPath);//显示图像
        }

        private bool insertInfo()
        {
            try
            {
                con.Open();//打开数据库连接
                StringBuilder strSql = new StringBuilder();//创建StringBuilder对象
                strSql.Append("insert into 档案信息 values(@档案编号,@工号,");//追加文本内容
                strSql.Append("@姓名,@照片,@性别,@出生日期,@籍贯,@工龄,@电话,");//追加文本内容
                strSql.Append("@部门名称,@技术职称,@婚姻状态,@健康状态)");//追加文本内容
                SqlCommand cmd = new SqlCommand(strSql.ToString(), con);//创建数据库命令对象
                cmd.Parameters.Add("@档案编号", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox1.Text.Trim().ToString();
                cmd.Parameters.Add("@工号", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox2.Text.Trim().ToString();
                cmd.Parameters.Add("@姓名", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox3.Text.Trim().ToString();
                cmd.Parameters.Add("@照片", SqlDbType.Text).Value = strPath;//添加参数并赋值
                cmd.Parameters.Add("@性别", SqlDbType.Text).Value =//添加参数并赋值
                    this.comboBox1.Text.Trim().ToString();
                cmd.Parameters.Add("@出生日期", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox4.Text.Trim().ToString();
                cmd.Parameters.Add("@籍贯", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox5.Text.Trim().ToString();
                cmd.Parameters.Add("@工龄", SqlDbType.Int).Value =//添加参数并赋值
                    Convert.ToInt16(this.textBox6.Text.Trim().ToString());
                cmd.Parameters.Add("@电话", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox6.Text.Trim().ToString();
                cmd.Parameters.Add("@部门名称", SqlDbType.Text).Value =//添加参数并赋值
                    this.textBox7.Text.Trim().ToString();
                cmd.Parameters.Add("@技术职称", SqlDbType.Text).Value =//添加参数并赋值
                    this.comboBox2.Text.Trim().ToString();
                cmd.Parameters.Add("@婚姻状态", SqlDbType.Text).Value =//添加参数并赋值
                    this.comboBox3.Text.Trim().ToString();
                cmd.Parameters.Add("@健康状态", SqlDbType.Text).Value =//添加参数并赋值
                    this.comboBox4.Text.Trim().ToString();
                cmd.ExecuteNonQuery();//执行SQL语句
                con.Close();//关闭数据库连接
                return true;//方法返回布尔值
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示！");
                return false;//方法返回布尔值
            }
        }

        #region//访问器
        private string 档案编号;
        private string 工号;
        private string 姓名;
        private string 照片;
        private string 性别;
        private string 出生日期;
        private string 籍贯;
        private int 工龄;
        private string 电话;
        private string 部门名称;
        private string 技术职称;
        private string 婚姻状态;
        private string 健康状态;

        private string ID
        {
            get { return 档案编号; }
            set { 档案编号 = value; }
        }
        private string NumID
        {
            get { return 工号; }
            set { 工号 = value; }
        }
        private string name
        {
            get { return 姓名; }
            set { 姓名 = value; }
        }
        private string pic
        {
            get { return 照片; }
            set { 照片 = value; }
        }
        private string sex
        {
            get { return 性别; }
            set { 性别 = value; }
        }
        private string birthday
        {
            get { return 出生日期; }
            set { 出生日期 = value; }
        }
        private string city
        {
            get { return 籍贯; }
            set { 籍贯 = value; }
        }
        private int years
        {
            get { return 工龄; }
            set { 工龄 = value; }
        }
        private string phone
        {
            get { return 电话; }
            set { 电话 = value; }
        }
        private string part
        {
            get { return 部门名称; }
            set { 部门名称 = value; }
        }
        private string state
        {
            get { return 技术职称; }
            set { 技术职称 = value; }
        }
        private string marriage
        {
            get { return 婚姻状态; }
            set { 婚姻状态 = value; }
        }
        private string health
        {
            get { return 健康状态; }
            set { 健康状态 = value; }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
