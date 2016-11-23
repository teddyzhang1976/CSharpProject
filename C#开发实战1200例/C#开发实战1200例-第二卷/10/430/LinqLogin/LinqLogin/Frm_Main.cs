using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqLogin
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;//获取用户名
            string pwd = txtPwd.Text;//获取密码
            //创建LINQ对象
            LinqClassDataContext linqDataContext = new LinqClassDataContext();
            //创建LINQ查询语句，查询到满足指定用户名和密码的用户
            var result = from v in linqDataContext.tb_Login
                         where v.Name == name && v.Pwd == pwd
                         select v;
            if (result.Count() > 0)
            {
                //输出相应信息
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }
    }
}
