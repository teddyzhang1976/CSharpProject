using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiGroupBy
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
            var query = from sto in dc.V_StoreInfo//查询库存表
                        group sto by new { sto.WarehouseCode, sto.ProductCode } into g//按仓库代码、商品代码分组
                        select new
                        {
                            仓库代码 = g.Key.WarehouseCode,
                            仓库名称 = g.Max(itm => itm.WareHouseName),
                            商品代码 = g.Key.ProductCode,
                            商品名称 = g.Max(itm => itm.ProductName),
                            库存数量 = g.Sum(itm => itm.Quantity)
                        };
            dataGridView1.DataSource = query;//将分组的结果集绑定到dataGridView1
        }
    }
}
