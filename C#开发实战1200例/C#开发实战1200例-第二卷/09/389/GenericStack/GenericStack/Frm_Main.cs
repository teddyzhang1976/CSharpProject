using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericStack
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Stack<UserInfo> users = new Stack<UserInfo>();//创建泛型堆栈
            for (int i = 0; i < 10; i++)//使用for语句对堆栈进行入栈操作
            {
                users.Push(new UserInfo(i < 5 ? 0 : 1, "User0" + i.ToString(), "0" + i.ToString()));
            }
            //LINQ过滤泛型堆栈
            var query = from item in users
                        where item.UserName == "User00" || item.UserName == "User09"
                        select item;
            label1.Text="显示查询结果：\n";
            foreach (var item in query)//遍历查询结果
            {
                label1.Text+=string.Format("({0},{1})", item.UserCode, item.UserName);
                label1.Text+="\n";
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
