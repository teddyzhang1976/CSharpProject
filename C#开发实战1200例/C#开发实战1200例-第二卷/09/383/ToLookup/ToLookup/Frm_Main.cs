using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToLookup
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //构造泛型列表
            List<UserInfo> users = new List<UserInfo> { 
            new UserInfo{UserCode=1, UserName="User001", Password="001"},
            new UserInfo{UserCode=1, UserName="User002", Password="002"},
            new UserInfo{UserCode=2, UserName="User003", Password="003"},
            new UserInfo{UserCode=2, UserName="User004", Password="004"}};
            //使用LINQ查找用户代码小于3的列表
            //此时的query变量的类型是IEnumerable<UserInfo>类型
            var query = from item in users
                        where item.UserCode < 3
                        select item;
            //使用ToLookup方法将query转换为一对多字典类型
            ILookup<int, UserInfo> userLookup = query.ToLookup(itm => itm.UserCode);

            label1.Text = "ILookup的结果是：\n";
            foreach (var user in userLookup)//遍历查询结果
            {
                label1.Text += user.Key;//显示主键
                label1.Text += "   ";
                foreach (var user2 in user)//遍历所有值
                {
                    label1.Text += user2.UserName + " , ";//显示键值
                }
                label1.Text += "\n";
            }
        }
    }
    public class UserInfo
    {
        public int UserCode { get; set; }//用户代码
        public string UserName { get; set; }//用户名称
        public string Password { get; set; }//密码
    }
}
