using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditDataByLINQ
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
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            binginfo();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }
        int Pid;//定义一个变量，用来记录选中的编号
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)//判断是否选中行
            {
                linq = new linqtosqlDataContext(strCon);//初始化LINQ连接对象
                Pid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);//记录选中的编号
                //查询符合指定条件的信息
                var result = from info in linq.tb_User
                             where info.ID == Pid
                             select new
                             {
                                 Name = info.User_Name,//获取姓名
                                 Sex = info.User_Sex,//获取性别
                                 Age = info.User_Age,//获取年龄
                                 Mary = info.User_Marriage,//获取婚姻状况
                                 Duty = info.User_Duty,//获取职位
                                 Phone = info.User_Phone,//获取联系电话
                                 Address = info.User_Address//获取联系地址
                             };
                foreach (var item in result)
                {
                    txtName.Text = item.Name.Trim();//显示姓名
                    cbbSex.Text = item.Sex.Trim();//显示性别
                    txtage.Text = item.Age.Trim();//显示年龄
                    cbbmary.Text = item.Mary.Trim();//显示婚姻状况
                    cbbduty.Text = item.Duty.Trim();//显示职位
                    txtphone.Text = item.Phone.Trim();//显示联系电话
                    txtaddress.Text = item.Address.Trim();//显示联系地址
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断是否输入姓名、年龄、电话和家庭住址
            if (txtaddress.Text != "" && txtage.Text != "" && txtName.Text != "" && txtphone.Text != "")
            {
                if (txtphone.Text.Length != 11)//如果电话号码错误
                {
                    MessageBox.Show("电话号码位数不正确");//弹出提示
                }
                else
                {
                    linq = new linqtosqlDataContext(strCon);
                    var resultChange = from info in linq.tb_User
                                       where info.ID == Pid//创建linq，设置其根据ID值进行修改
                                       select info;
                    foreach (tb_User users in resultChange)
                    {
                        users.User_Name = txtName.Text;//姓名
                        users.User_Sex = cbbSex.Text;//性别
                        users.User_Age = txtage.Text;//年龄
                        users.User_Marriage = cbbmary.Text;//婚姻状况
                        users.User_Duty = cbbduty.Text;//职位
                        users.User_Phone = txtphone.Text;//电话
                        users.User_Address = txtaddress.Text;//家庭地址
                        linq.SubmitChanges();//SubmitChanges方法提交修改
                    }
                    MessageBox.Show("修改成功");//弹出成功的提示
                    binginfo();//重新绑定数据
                }
            }
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
            if (txtage.Text.StartsWith("0"))
            {
                MessageBox.Show("年龄不能以0开头");
                txtage.Text = "";
            }
        }
    }
}
