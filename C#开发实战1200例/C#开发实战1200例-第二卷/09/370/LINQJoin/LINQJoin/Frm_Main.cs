using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LINQJoin
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<SaleBill> bills = new List<SaleBill>//创建销售单列表
        {
            new SaleBill("XS001","王*科",Convert.ToDateTime("2010-1-1")),
            new SaleBill("XS002","王*军",Convert.ToDateTime("2010-2-1")),
            new SaleBill("XS003","赵*东",Convert.ToDateTime("2010-3-1"))
        };
            List<SaleProduct> products = new List<SaleProduct>//创建销售商品列表
        {
            new SaleProduct("XS001","冰箱",1,2000),
            new SaleProduct("XS001","洗衣机",2,600),
            new SaleProduct("XS002","电暖风",3,50),
            new SaleProduct("XS002","吸尘器",4,200),
            new SaleProduct("XS003","手机",1,990)
        };
            //关联销售单列表和销售商品列表        
            var query= bills.Join(products,
                               b => b.SaleBillCode,
                               p => p.SaleBillCode,
                               (b, p) => new
                               {
                                   销售单号 = b.SaleBillCode,
                                   销售日期 = b.SaleDate,
                                   销售员 = b.SaleMan,
                                   商品名称 = p.ProductName,
                                   数量 = p.Quantity,
                                   单价 = p.Price,
                                   金额 = p.Quantity * p.Price
                               });
            dataGridView1.DataSource = query.ToList();//数据绑定
        }
    }
    class SaleBill//销售单据类
    {
        public SaleBill(string saleBillCode, string saleMan, DateTime saleDate)
        {
            this.SaleBillCode = saleBillCode;
            this.SaleMan = saleMan;
            this.SaleDate = saleDate;
        }
        public string SaleBillCode { get; set; }//销售单号
        public string SaleMan { get; set; }//销售员
        public DateTime SaleDate { get; set; }//销售日期
    }

    class SaleProduct//销售商品类
    {
        public SaleProduct(string saleBillCode, string productName, int quantity, double price)
        {
            this.SaleBillCode = saleBillCode;
            this.ProductName = productName;
            this.Quantity = quantity;
            this.Price = price;
        }
        public string SaleBillCode { get; set; }//销售单号
        public string ProductName { get; set; }//商品名称
        public int Quantity { get; set; }//数量
        public double Price { get; set; }//单价
    }
}
