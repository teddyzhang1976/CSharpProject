using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelDataByLINQ
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
        private void bindinfo()
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
            bindinfo();
        }
        int id;//定义一个变量，用来记录选中的编号
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)//判断是否选中行
            {
                id =Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);//记录用户选择的编号
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)//判断是否选择了项目
            {
                linq = new linqtosqlDataContext(strCon);
                var result = from info in linq.tb_User
                             where info.ID == id
                             select info;//创建linq，并设置删除的条件
                linq.tb_User.DeleteAllOnSubmit(result);//通过DeleteAllOnSubmit方法删除指定的数据
                linq.SubmitChanges();//提交对数据表的修改
                MessageBox.Show("删除成功");//弹出提示
                bindinfo();//重新绑定数据
            }
            else//如果没有选择项
            {
                MessageBox.Show("请选择删除项");//显示提示信息
            }
        }
    }
}
