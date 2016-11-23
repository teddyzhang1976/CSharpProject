using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindDataByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        #region 定义公共变量及Linq连接对象
        //定义数据库连接字符串
        string strCon = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
        linqtosqlDataContextDataContext linq; //创建Linq连接对象
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            txtKey.Focus();
        }

        private void SearchInfo()
        {
            linq = new linqtosqlDataContextDataContext(strCon);//初始化Linq连接对象
            if (txtKey.Text == "")//如果没有输入查询的关键字
            {
                var result = from info in linq.tb_User//查找数据库中所有的员工信息
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
            else//如果输入了关键字
            {
                int i = comboBox1.SelectedIndex;//获取查询的范围
                switch (i)
                {
                    case 0://如果根据姓名查找
                        var resultName = from info in linq.tb_User
                                         where info.User_Name.IndexOf(txtKey.Text) >= 0//模糊查询
                                         select new
                                         {
                                             编号 = info.ID,
                                             姓名 = info.User_Name,
                                             性别 = info.User_Sex,
                                             年龄 = info.User_Age,
                                             婚姻状况 = info.User_Marriage,
                                             职位 = info.User_Duty,
                                             联系电话 = info.User_Phone,
                                             联系地址 = info.User_Address
                                         };
                        dataGridView1.DataSource = resultName;//将检索的数据绑定到dataGridView1控件
                        break;
                    case 1://如果根据性别查找
                        var resultSex = from info in linq.tb_User
                                        where info.User_Sex == txtKey.Text.Trim()//判断员工性别是否等于输入的性别
                                        select new
                                        {
                                            编号 = info.ID,
                                            姓名 = info.User_Name,
                                            性别 = info.User_Sex,
                                            年龄 = info.User_Age,
                                            婚姻状况 = info.User_Marriage,
                                            职位 = info.User_Duty,
                                            联系电话 = info.User_Phone,
                                            联系地址 = info.User_Address
                                        };
                        dataGridView1.DataSource = resultSex;//将检索的数据绑定到dataGridView1控件
                        break;
                    case 2://如果根据年龄查找
                        //判断数据库中的员工年龄是否以输入的关键字开头
                        var resultAge = from info in linq.tb_User
                                        where info.User_Age.StartsWith(txtKey.Text)
                                        select new
                                        {
                                            编号 = info.ID,
                                            姓名 = info.User_Name,
                                            性别 = info.User_Sex,
                                            年龄 = info.User_Age,
                                            婚姻状况 = info.User_Marriage,
                                            职位 = info.User_Duty,
                                            联系电话 = info.User_Phone,
                                            联系地址 = info.User_Address
                                        };
                        dataGridView1.DataSource = resultAge;//将检索的数据绑定到dataGridView1控件
                        break;
                    case 3://如果根据职位查找
                        var resultDuty = from info in linq.tb_User
                                         where info.User_Duty == txtKey.Text.Trim()//判断员工职位是否等于输入的关键字
                                         select new
                                         {
                                             编号 = info.ID,
                                             姓名 = info.User_Name,
                                             性别 = info.User_Sex,
                                             年龄 = info.User_Age,
                                             婚姻状况 = info.User_Marriage,
                                             职位 = info.User_Duty,
                                             联系电话 = info.User_Phone,
                                             联系地址 = info.User_Address
                                         };
                        dataGridView1.DataSource = resultDuty;//将检索的数据绑定到dataGridView1控件
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchInfo();
        }
    }
}
