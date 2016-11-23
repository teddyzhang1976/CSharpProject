using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetConnectionInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //从配置文件中取连接字符串
            string conStr = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";
            DataClassesDataContext dc = new DataClassesDataContext(conStr);//创建数据上下文实例
            System.Data.Common.DbConnection con = dc.Connection;//获取其连接
            con.Open();//打开连接
            //显示数据库连接的信息
            label1.Text = "连接字符串：" + con.ConnectionString + "\n";
            label1.Text += "连接超时时间：" + con.ConnectionTimeout.ToString() + "\n";
            label1.Text += "数据库名：" + con.Database + "\n";
            label1.Text += "数据源：" + con.DataSource + "\n";
            label1.Text += "服务器版本：" + con.ServerVersion + "\n";
            label1.Text += "状态：" + con.State.ToString() + "\n";
            label1.Text += "执行命令的最大时间：" + dc.CommandTimeout.ToString() + "\n";
            label1.Text+="是否延时加载：" + dc.DeferredLoadingEnabled.ToString();
        }
    }
}
