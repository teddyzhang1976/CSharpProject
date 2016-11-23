using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISCurrentUser
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppDomain domain = System.Threading.Thread.GetDomain();//获取当前域
            domain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);//将操作系统组映射到角色
            //获取当前系统组
            System.Security.Principal.WindowsPrincipal principal = (System.Security.Principal.WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.User))//判断是否为普通用户
            {
                label1.Text += "当前用户为普通用户\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PowerUser))//判断是否为超级用户
            {
                label1.Text += "当前用户为超级用户\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))//判断是否为系统管理员
            {
                label1.Text += "当前用户为系统管理员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.SystemOperator))//判断是否为系统操作员
            {
                label1.Text += "当前用户为系统操作员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.BackupOperator))//判断是否为备份操作员
            {
                label1.Text += "当前用户为备份操作员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PowerUser))//判断是否为打印操作员
            {
                label1.Text += "当前用户为打印操作员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Replicator))//判断是否为复制操作员
            {
                label1.Text += "当前用户为复制操作员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))//判断是否为账户操作员
            {
                label1.Text += "当前用户为账户操作员\n";
            }
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Guest))//判断是否为来宾账户
            {
                label1.Text += "当前用户为来宾账户\n";
            }
        }
    }
}
