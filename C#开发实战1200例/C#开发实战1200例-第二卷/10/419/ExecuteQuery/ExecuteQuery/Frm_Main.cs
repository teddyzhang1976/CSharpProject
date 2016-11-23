using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExecuteQuery
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        DataClassesDataContext dc = new DataClassesDataContext();//创建LINQ对象
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //填充仓库下拉列表框
            var WareHouseQuery = dc.WarehouseInfo.Select(itm => new { itm.WareHouseCode, itm.WareHouseName });
            comboBox1.DataSource = WareHouseQuery;//对comboBox1进行数据绑定
            comboBox1.DisplayMember = "WareHouseName";//指定要显示的字段
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from V_StoreInfo where 1=1";
            if (comboBox1.SelectedIndex > -1)//仓库下拉列表不为空
            {
                sql += " and WareHouseName = '" + comboBox1.Text + "'";
            }
            if (textBox1.Text.Trim()!= "")//商品助记码文本框不为空
            {
                sql += " and HelpCode like '" + textBox1.Text + "%'";
            }
            var query = dc.ExecuteQuery<V_StoreInfo>(sql);//执行SQL查询
            dataGridView1.DataSource = query.ToList();//对dataGridView1进行数据绑定
        }
    }
}
