using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Data.SqlClient;

namespace InputText
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btnConcel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string strA = null;//定义字符串字段
        string strB = null;//定义字符串字段
        private void txtPasword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPasword.Text != "mrsoft")//判断密码是否正确
            {
                errPassword.SetError(//显示密码错误信息
                    txtPasword, "密码确误");
            }
            else
            {
                errPassword.SetError(//显示密码错误信息
                    txtPasword, "");
                strA = txtPasword.Text;//得到密码字符串
            }
        }
     
        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (txtUser.Text != "mr")//判断用户名是否正确
            {
                errUser.SetError(//显示用户名错误信息
                    txtUser, "登录名错误");
            }
            else
            {
                errUser.SetError(//显示用户名错误信息
                    txtUser, "");
                strB = txtUser.Text;//得到用户名字符串
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (strB != null && strA != null)//验证用户名和密码是否正确
            { MessageBox.Show("登录成功"); }//弹出消息对话框
            else { MessageBox.Show("输入用户名和密码"); }//弹出消息对话框
        }
    }
}