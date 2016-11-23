using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Union
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
                           select new { si.ProductCode, si.ProductName, si.Quantity };
            var saleRetu = from sr in dc.V_SaleReturnInfo//销售返货
                           select new { sr.ProductCode, sr.ProductName, Quantity = sr.Quantity * (-1) };
            var sale2 = saleInfo.Union(saleRetu);//将销售信息和销售返货合并在一起
            var query = from item in sale2//按商品代码和商品名称分组合计销售数量
                        group item by new { item.ProductCode, item.ProductName } into g
                        select new
                        {
                            商品代码 = g.Key.ProductCode,
                            商品名称 = g.Key.ProductName,
                            销售总数 = g.Sum(itm => itm.Quantity)
                        };
            dataGridView1.DataSource = query;//将查询的结果集绑定到dataGridView1
        }
    }
}
