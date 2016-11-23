using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingleTableQuery
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext DC = new DataClassesDataContext();//创建数据上下文类的实例
            var query = from item in DC.WarehouseInfo
                        where item.Area >= 100//使用LINQ查询面积大于100平的仓库
                        orderby item.ShortName//按仓库名称排序
                        select item;
            dataGridView1.DataSource = query.ToList();//将查询结果集绑定到dataGridView1
        }
    }
}
