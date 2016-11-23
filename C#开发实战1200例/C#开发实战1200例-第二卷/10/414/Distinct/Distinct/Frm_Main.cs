using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distinct
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
            var query1 = dc.V_SaleReturnInfo.Select(itm => new { 商品代码 = itm.ProductCode, 商品名称 = itm.ProductName });//查找指定商品
            label1.Text="全部的商品返货记录如下\n";
            foreach (var item in query1)
            {
                label1.Text+=item + "\n";
            }
            var query2 = dc.V_SaleReturnInfo.Select(itm => new { 商品代码 = itm.ProductCode, 商品名称 = itm.ProductName }).Distinct();//去除重复记录
            label1.Text += "将返货记录中重复的商品去除\n";
            foreach (var item in query2)
            {
                label1.Text+=item + "\n";
            }
        }
    }
}
