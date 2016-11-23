using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompositeOrderby
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc =new DataClassesDataContext();//创建数据上下文类的实例
            //按商品分类、计量单位降序排序
            var query = from item in dc.ProductInfo
                        orderby item.ProductType descending, item.Unit descending
                        select item;
            dataGridView1.DataSource = query;//将查询结果集绑定到dataGridView1
        }
    }
}
