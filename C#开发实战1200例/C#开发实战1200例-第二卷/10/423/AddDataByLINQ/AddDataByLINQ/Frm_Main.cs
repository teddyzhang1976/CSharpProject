using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddDataByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //定义数据库连接字符串
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        linqtosqlDataContext linq; //创建Linq连接对象
        private void Form1_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }
        private void binginfo()
        {
            linq = new linqtosqlDataContext(strCon);//初始化Linq连接对象
            //查找数据库中所有的员工信息
            var result = from info in linq.tb_User
                         select new
                         {
                             编号 = info.ID,//显示编号
                             姓名 = info.User_Name.Trim(),//姓名
                             性别 = info.User_Sex.Trim(),//性别
                             年龄 = info.User_Age.Trim(),//年龄
                             婚姻状况 = info.User_Marriage.Trim(),//婚姻状况
                             职位 = info.User_Duty.Trim(),//职位
                             联系电话 = info.User_Phone.Trim(),//联系电话
                             联系地址 = info.User_Address.Trim()//联系地址
                         };
            dataGridView1.DataSource = result;//将检索的数据绑定到dataGridView1控件
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbbduty.SelectedIndex = 0;
            cbbmary.SelectedIndex = 0;
            cbbSex.SelectedIndex = 0;
            binginfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断是否输入姓名、年龄、电话和家庭住址
            if (txtaddress.Text != "" && txtage.Text != "" && txtName.Text != "" && txtphone.Text != "")
            {
                if (txtphone.Text.Length != 11)//判断输入的电话号码是否合法
                {
                    MessageBox.Show("电话号码位数不正确");//不合法则弹出提示
                }
                else//如果输入的电话号码合法
                {
                    linq = new linqtosqlDataContext(strCon);//创建linq连接对象
                    tb_User users = new tb_User();//创建tb_User对象
                    users.User_Name = txtName.Text.Trim();//设置姓名
                    users.User_Sex = cbbSex.Text;//性别
                    users.User_Age = txtage.Text;//年龄
                    users.User_Marriage = cbbmary.Text;//婚姻状况
                    users.User_Duty = cbbduty.Text;//职位
                    users.User_Phone = txtphone.Text;//电话
                    users.User_Address = txtaddress.Text;//家庭住址
                    linq.tb_User.InsertOnSubmit(users);//提交数据
                    linq.SubmitChanges();//执行对数据库的修改
                    binginfo();//重新绑定数据
                    MessageBox.Show("添加成功");//弹出提示
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtage_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtage.Text.StartsWith("0"))
            {
                MessageBox.Show("年龄不能以0开头");
                txtage.Text = "";
            }
        }
    }
}
