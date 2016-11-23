using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Last
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<Sale> SaleList = new List<Sale>//创建销售列表
    {
        new Sale("洗衣机",Convert.ToDateTime("2010-3-3"),600),
        new Sale("冰箱",Convert.ToDateTime("2010-12-12"),1900),
        new Sale("洗衣机",Convert.ToDateTime("2010-2-2"),550),
        new Sale("洗衣机",Convert.ToDateTime("2010-1-1"),500)
    };
            Sale sa = SaleList.Where(itm => itm.ProductName == "洗衣机").OrderBy(itm => itm.SaleDate).Last();//获取洗衣机最后一次销售单价
            //输出查询结果
            label1.Text = "数据源：{\"洗衣机\",\"2010-3-3\",600}" + Environment.NewLine + "        {\"洗衣机\",\"2010-2-2\",550}" + Environment.NewLine + "        {\"洗衣机\",\"2010-1-1\",500}";//数据源
            label2.Text = "查询表达式：Last()";//查询表达式/操作
            label3.Text = "查询结果：" + sa.SalePrice.ToString();//查询结果
        }
    }
    class Sale
    {
        public Sale(string productName, DateTime saleDate, double salePrice)
        {
            this.ProductName = productName;
            this.SaleDate = saleDate;
            this.SalePrice = salePrice;
        }
        public string ProductName { get; set; }//货品名称
        public DateTime SaleDate { get; set; }//销售日期
        public double SalePrice { get; set; }//销售单价
    }
}
