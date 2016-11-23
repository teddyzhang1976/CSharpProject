using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericDictionary
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Dictionary<int, UserInfo> users = new Dictionary<int, UserInfo>();//创建泛型字典
            users.Add(3, new UserInfo(1, "滕*敏", "01"));//为泛型字典添加3个元素
            users.Add(2, new UserInfo(2, "滕*娜", "02"));
            users.Add(1, new UserInfo(3, "X家兴", "03"));
            //按键值对泛型字典进行排序操作
            var query = from item in users
                        where item.Value.UserName.CompareTo("滕*") > 0//用户名大于"滕立"
                        orderby item.Key
                        select item;
            label1.Text = "显示查询结果：\n";
            foreach (var item in query)//显示查询结果
            {
                label1.Text += string.Format("({0},{1})", item.Key, item.Value.UserName);
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
