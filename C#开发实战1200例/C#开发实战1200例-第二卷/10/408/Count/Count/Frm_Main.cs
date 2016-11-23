using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Count
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
            //统计每种商品的销售次数
            var query = from det in dc.V_SaleDetail
                        group det by det.ProductCode into g//按商品代码分组
                        select new
                        {
                            商品代码 = g.Key,
                            商品名称 = g.Max(itm => itm.ProductName),
                            销售次数 = g.Count()//使用Count方法统计销售次数
                        };
            dataGridView1.DataSource = query;//将查询结果集绑定到dataGridView1
        }
    }
}
