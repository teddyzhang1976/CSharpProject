using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aggregate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();//创建LINQ对象
            //将销售商品明细表中的金额字段值取出，并转换为数组
            double[] amountArray = dc.V_SaleDetail.Select(itm => itm.amount).ToArray<double>();
            double amountSum = amountArray.Aggregate((a, b) => a + b);//计算商品销售总额
            label1.Text="销售总额是：" + amountSum.ToString("#,##0.00");//显示销售总额
        }
    }
}
