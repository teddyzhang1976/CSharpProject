using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Intersect
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
            var saleInfo = from si in dc.V_SaleInfo//销售信息
                           select new
                           {
                               商品代码 = si.ProductCode,
                               商品名称 = si.ProductName
                           };
            var saleRetu = from sr in dc.V_SaleReturnInfo//销售返货
                           select new
                           {
                               商品代码 = sr.ProductCode,
                               商品名称 = sr.ProductName
                           };
            var query = saleInfo.Intersect(saleRetu);//取交集
            dataGridView1.DataSource = query;//将查询的结果集绑定到dataGridView1
        }
    }
}
