using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RefreshFormByChildForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 本实例应该设置主窗体的IsMdiContainer属性为true、MainMenuStrip属性为所添加的菜单栏、WindowState属性为Maximized、窗体名称为FrmMain、设置AllowUserToAddRows属性为false
        /// </summary>

        #region 声明的变量
        public static bool flag = false;//标识是否创建新的子窗体
        Frm_Child BabyWindow = new Frm_Child();//实例化一个子窗体
        DataSet PubsSet = new DataSet(); //定义一个数据集对象
        public static string[] IDArray; //声明一个一维字符串数组
        public DataTable IDTable;       //声明一个数据表对象
        SqlDataAdapter IDAdapter;        //声明一个数据读取器对象
        SqlDataAdapter PubsAdapter;       //声明一个数据读取器对象
        SqlConnection ConnPubs;           //声明一个数据库连接对象
        SqlCommand PersonalInformation;    //声明一个执行SQL语句的对象
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string ConnString = "Data Source=localhost;DataBase=db_TomeOne;UID=sa;Pwd=hbyt2008!@#;";//数据库连接字符串
            string AdapterString = "select userID as 编号,userName as 姓名 ,phone as 电话,address as 住址 from tb_User";//用于查询的字符串
            string IDString = "select userID from tb_User";//读取数据库中用户的ID编号字符串
            ConnPubs = new SqlConnection(ConnString);//建立数据库连接
            PubsAdapter = new SqlDataAdapter(AdapterString, ConnPubs);//创建PubsAdapter数据读取器
            IDAdapter = new SqlDataAdapter(IDString, ConnPubs);//用于读取用户编号的读取器
            PubsAdapter.Fill(PubsSet, "tb_User");//填充PubsSet数据集
            IDAdapter.Fill(PubsSet, "ID");//填充PubsSet数据集
            DataTable PubsTable = PubsSet.Tables["tb_User"];//将数据写入PubsTable表
            IDTable = PubsSet.Tables["ID"];//将数据写入ID表
            IDArray = new string[IDTable.Rows.Count];//为数组定义最大长度
            dataGridView1.DataSource = PubsTable.DefaultView;//设置dataGridView1的数据源
            for (int i = 0; i < IDTable.Rows.Count; i++)   //循环遍历数据表中的每一行数据
            {
                for (int j = 0; j < IDTable.Columns.Count; j++)//循环遍历数据表中的每一列数据
                {
                    IDArray[i] = IDTable.Rows[i][j].ToString(); //将数据表中的数据添加至一个一维数组
                }
            }
        }

        #region 增加单一的FrmChild窗体
        private void AddandDelete_Click(object sender, EventArgs e)
        {
            if (flag == false)//判断标识的值决定是否创建窗体
            {
                CreateFrmChild();//创建子窗体
            }
            for (int i = 0; i < this.dataGridView1.Controls.Count; i++)//循环遍历DataGridView控件上的控件集
            {
                if (this.dataGridView1.Controls[i].Name.Equals(BabyWindow.Name))//当存在子窗体时
                {
                    flag = true;//改变标识Flag的值
                    break;//退出循环体
                }
            }
        }
        #endregion

        private void ExitProject_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出本程序
        }

        #region 创建子窗体的CreateFrmChild方法
        public void CreateFrmChild()
        {
            Frm_Child BabyWindow = new Frm_Child();//实例化一个子窗体
            BabyWindow.MdiParent = this;//设置子窗体的父窗体为当前窗体
            this.dataGridView1.Controls.Add(BabyWindow);//在DataGridView控件中添加子窗体
            //BabyWindow.UpdateDataGridView += new EventHandler(BabyWindow_UpdateDataGridView);
            BabyWindow.Show();//显示子窗体


            BabyWindow.OnUpdateDataGridView += new UpdateDataHandler(BabyWindow_UpdateDataGridView);
        }

        // void BabyWindow_UpdateDataGridView(object sender,EventArgs e)
        void BabyWindow_UpdateDataGridView()
        {
            if (Frm_Child.GlobalFlag == false)    //当单击删除按钮时
            {
                if (ConnPubs.State == ConnectionState.Closed) //当数据库处于断开状态时
                {
                    ConnPubs.Open();                //打开数据库的连接
                }
                string AfreshString = "delete tb_User where userID=" + Frm_Child.DeleteID.Trim();//定义一个删除数据的字符串
                PersonalInformation = new SqlCommand(AfreshString, ConnPubs); //执行删除数据库字段
                PersonalInformation.ExecuteNonQuery(); //执行SQL语句并返回受影响的行数
                ConnPubs.Close();                     //关闭数据库
                DisplayData();                          //显示数据库更新后的内容
                MessageBox.Show("数据删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//弹出删除数据成功的提示
            }
            else
            {
                if (ConnPubs.State == ConnectionState.Closed) //当数据库处于关闭状态时
                {
                    ConnPubs.Open();                        //打开数据库
                }
                string InsertString = "insert into tb_User values('" + Frm_Child.idContent + "','" + Frm_Child.nameContent + "','" + Frm_Child.phoneContent + "','" + Frm_Child.addressContent + "')";//定义一个插入数据的字符串变量
                PersonalInformation = new SqlCommand(InsertString, ConnPubs);//执行插入数据库字段
                PersonalInformation.ExecuteNonQuery();//执行SQL语句并返回受影响的行数
                ConnPubs.Close();                    //关闭数据库
                DisplayData();                         //显示更新后的数据
                MessageBox.Show("数据添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//弹出添加成功的提示信息
            }
        }
        #endregion

        #region 用于读取数据库的DisplayData方法
        public void DisplayData()
        {
            PubsSet.Clear();
            string ConnString = "Data Source=localhost;DataBase=db_TomeOne;UID=sa;Pwd=hbyt2008!@#;";//数据库连接字符串
            ConnPubs = new SqlConnection(ConnString);//建立数据库连接
            string DisplayString = "select userId as 编号,userName as 姓名 ,phone as 电话,address as 住址 from tb_User";//定义读取数据库的字段
            SqlDataAdapter PersonalAdapter = new SqlDataAdapter(DisplayString, ConnPubs); //定义一个读取数据库数据的读取器
            PersonalAdapter.Fill(PubsSet, "tb_User"); //向表DisplayTable中填充数据
            dataGridView1.DataSource = PubsSet.Tables["tb_User"].DefaultView;//设定DataGridView控件的数据源
        }
        #endregion
    }
}
