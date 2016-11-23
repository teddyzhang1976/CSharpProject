using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contains
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
            //列出库存中从来没有销售过的商品
            var query = from sto in dc.V_StoreInfo
                        //where子句中应用了子查询
                        where !(from sal in dc.V_SaleInfo
                                select sal.ProductCode).Contains(sto.ProductCode)
                        select new
                        {
                            仓库 = sto.WareHouseName,
                            商品名称 = sto.ProductName,
                            数量 = sto.Quantity,
                            单价 = sto.Price,
                            金额 = sto.Amount
                        };
            dataGridView1.DataSource = query;//将查询结果绑定到dataGridView1
        }
    }
}
