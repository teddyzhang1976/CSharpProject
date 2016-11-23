using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseExists
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;";//定义数据库连接字符串
            DataClassesDataContext dc = new DataClassesDataContext(conStr);//创建数据上下文类的实例
            if (dc.DatabaseExists() == true)//如果该数据库存在
            {
                label1.Text=dc.Connection.Database + "数据库已经存在！";
            }
            else
            {
                label1.Text = dc.Connection.Database + "数据库不存在！";
            }
        }
    }
}
