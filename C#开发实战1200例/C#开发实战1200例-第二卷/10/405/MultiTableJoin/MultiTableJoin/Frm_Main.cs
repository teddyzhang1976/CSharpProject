using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiTableJoin
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
            var query = from sc in dc.SaleContent//销售主表
                        join sd in dc.SaleDetail on sc.SaleBillCode equals sd.SaleBillCode//按销售单据号关联销售主从表
                        join pi in dc.ProductInfo on sd.ProductCode equals pi.ProductCode//按商品代码关联商品信息表
                        join ei in dc.EmployeeInfo on sc.SaleMan equals ei.EmployeeCode//按人员代码关联员工表
                        join wi in dc.WarehouseInfo on sc.WareHouse equals wi.WareHouseCode//按仓库代码关联仓库信息表
                        join ci in dc.ClientInfo on sc.ClientCode equals ci.ClientCode//按客户代码关联客户信息表
                        select new
                        {
                            ID = sc.ID,
                            SaleBillCode = sc.SaleBillCode,//销售单据号
                            SaleMan = ei.Name,//从员工表取销售员名称
                            SaleDate = sc.SaleDate,//销售日期
                            Provider = ci.ShortName,//从客户表取购买单位名称
                            WareHouse = wi.ShortName,//从仓库表取仓库名称
                            ProductCode = pi.ProductCode,//从商品信息表取商品代码
                            ProductName = pi.ShortName,//商品名称
                            Quantity = sd.Quantity,//数量
                            Price = sd.Price,//单价
                            Amount = sd.Quantity * sd.Price,//金额
                            GrossProfit = sd.Quantity * (sd.Price - sd.Cost)//毛利=销售金额-商品成本
                        };
            dataGridView1.DataSource = query;//将查询的结果集绑定到dataGridView1
        }
    }
}
