using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericQueue
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Queue<UserInfo> users = new Queue<UserInfo>();//创建泛型队列
            for (int i = 0; i < 10; i++)//为泛型队列添加元素
            {
                users.Enqueue(new UserInfo(i < 5 ? 0 : 1, "User0" + i.ToString(), "0" + i.ToString()));
            }
            //将泛型队列按用户名降序排列
            var query = users.OrderByDescending(itm => itm.UserName);
            label1.Text = "显示查询结果：\n";
            foreach (var item in query)//显示查询结果
            {
                label1.Text += string.Format("({0},{1})", item.UserCode, item.UserName);
                label1.Text += "\n";
            }
        }
    }
    public class UserInfo
    {
        public UserInfo(int userCode, string userName, string password)//初始化数据成员的构造函数
        {
            UserCode = userCode;
            UserName = userName;
            Password = password;
        }
        public int UserCode { get; set; }//用户代码
        public string UserName { get; set; }//用户名称
        public string Password { get; set; }//密码
    }
}
