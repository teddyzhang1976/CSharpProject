using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //构造List<UserInfo>泛型列表
            List<UserInfo> users = new List<UserInfo> { 
            new UserInfo{UserCode=1, UserName="User001", Password="001"},
            new UserInfo{UserCode=2, UserName="User002", Password="002"},
            new UserInfo{UserCode=3, UserName="User003", Password="003"},
            new UserInfo{UserCode=4, UserName="User004", Password="004"}};
            //使用LINQ查询用户名等于User001或密码等于003的列表项
            //此时的query变量的类型是IEnumerable<UserInfo>类型
            var query = from item in users
                        where item.UserName == "User001" || item.Password == "003"
                        select item;
            //使用ToList方法将IEnumerable<UserInfo>类型转换为List<UserInfo>类型
            List<UserInfo> filteredUsers = query.ToList<UserInfo>();
            //将泛型列表绑定DataGridView
            dataGridView1.DataSource = filteredUsers.ToList();
        }
    }
    public class UserInfo
    {
        public int UserCode { get; set; }//用户代码
        public string UserName { get; set; }//用户名称
        public string Password { get; set; }//密码
    }
}
