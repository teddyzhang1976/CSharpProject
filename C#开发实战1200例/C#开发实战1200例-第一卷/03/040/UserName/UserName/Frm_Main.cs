using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "Admin")//判断是否输入正确用户名
            {
                MessageBox.Show("登陆成功！", "提示！");//提示登陆成功
            }
            else
            {
                MessageBox.Show("用户名错误","错误！");//提示登陆不成功
            }
        }
    }
}
