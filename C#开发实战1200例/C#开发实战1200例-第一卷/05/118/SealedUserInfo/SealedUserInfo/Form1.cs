using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SealedUserInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 通过sealed关键字声明密封类，防止类被继承，有效保护重要信息
        /// </summary>
        public sealed class myClass
        {
            private string name = "";//string类型变量,用来记录用户名
            private string pwd = "";//string类型变量,用来记录密码
            /// <summary>
            /// 用户名
            /// </summary>
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            /// <summary>
            /// 密码
            /// </summary>
            public string Pwd
            {
                get
                {
                    return pwd;
                }
                set
                {
                    pwd = value;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出当前应用程序
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("用户名和密码不能为空","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                myClass myclass = new myClass();	//实例化密封类对象
                myclass.Name = txtUser.Text;				//为密封类中的编号属性赋值
                myclass.Pwd = txtPwd.Text;				//为密封类中的名称属性赋值
                MessageBox.Show("登录成功，用户名："+myclass.Name+" 密码："+myclass.Pwd,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
