using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcedureQuery
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//创建数据上下文类的实例
            var query = dc.P_queryWarehouseInfo(textBox1.Text);//调用存储过程返回仓库信息
            dataGridView1.DataSource = query;//将查询结果绑定到dataGridView1
        }
    }
}
