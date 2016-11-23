using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericSortedList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //构造泛型排序列表
            SortedList<int, UserInfo> uses = new SortedList<int, UserInfo>();
            //为泛型排序列表添加元素
            uses.Add(2, new UserInfo(2, "User02", "02"));
            uses.Add(1, new UserInfo(3, "User03", "03"));
            uses.Add(3, new UserInfo(1, "User01", "01"));
           label1.Text="未按用户名排序前的查询结果:\n";
            foreach (var item in uses)//泛型排序列表按键自动进行排序
            {
                label1.Text+=string.Format("({0},{1})", item.Key, item.Value.UserName);
                label1.Text += "\n";
            }
            //按用户名对泛型排序列表进行排序
            var query = from item in uses
                        orderby item.Value.UserName
                        select item;
            label1.Text += "按用户名排序后的查询结果:\n";
            foreach (var item in query)//遍历查询结果
            {
                label1.Text+=string.Format("({0},{1})", item.Key, item.Value.UserName);
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
