using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDictionary
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
            new UserInfo{UserCode=1, UserName="赵*东", Password="001"},
            new UserInfo{UserCode=2, UserName="王*科", Password="002"},
            new UserInfo{UserCode=3, UserName="王*军", Password="003"},
            new UserInfo{UserCode=4, UserName="吕*双", Password="004"}};
            //使用LINQ查找用户名称中包含"王"的序列
            //此时的query变量的类型是IEnumerable<UserInfo>类型
            var query = from item in users
                        where item.UserName.IndexOf("王") > -1
                        select item;
            //使用ToDictionary方法将query转换为字典类型
            Dictionary<int, UserInfo> userDict = query.ToDictionary(itm => itm.UserCode);

            label1.Text = "Dictionary的结果是：\n";
            foreach (var user in userDict)
            {
                string temp = string.Format("(Key:{0},Value:{1})", user.Key, user.Value.UserName);
                label1.Text += temp + "\n";
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
