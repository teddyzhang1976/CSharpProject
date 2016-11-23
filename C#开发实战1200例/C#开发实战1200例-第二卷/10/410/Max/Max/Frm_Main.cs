using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Max
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
            //统计每种商品的最高销售价
            var query = from det in dc.V_SaleDetail
                        group det by det.ProductCode into g//按商品代码分组
                        select new
                        {
                            商品代码 = g.Key,
                            商品名称 = g.Max(itm => itm.ProductName),
                            最高销售价 = g.Max(itm => itm.Price)//统计每种商品的最高销售价
                        };
            dataGridView1.DataSource = query;//对dataGridView1进行数据绑定
        }
    }
}
