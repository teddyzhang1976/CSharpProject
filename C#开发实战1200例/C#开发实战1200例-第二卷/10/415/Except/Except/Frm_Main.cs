using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Except
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//创建数据上下文类的实例
            var saleInfo = dc.V_SaleInfo.Select(itm => new { itm.ProductCode, itm.ProductName });//销售信息
            var saleRetu = dc.V_SaleReturnInfo.Select(itm => new { itm.ProductCode, itm.ProductName });//销售返货
            var query = saleInfo.Except(saleRetu);//取差集
            dataGridView1.DataSource = query;//将查询的结果集绑定到dataGridView1
        }
    }
}
