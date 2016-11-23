using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynamicQuery
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
            comboBox1.DataSource = WareHouseQuery;
            comboBox1.DisplayMember = "WareHouseName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)//仓库下拉列表不为空
            {
                if (textBox1.Text.Trim() != "")//商品助记码文本框不为空
                {
                    //调用通用查询方法
                    var query = ConditionQuery<V_StoreInfo>(dc.V_StoreInfo, itm => itm.WareHouseName == comboBox1.Text && itm.HelpCode.StartsWith(textBox1.Text));
                    dataGridView1.DataSource = query.ToList();//将查询结果绑定到dataGridView1
                }
                else//商品助记码文本框为空
                {
                    var query = ConditionQuery<V_StoreInfo>(dc.V_StoreInfo, itm => itm.WareHouseName == comboBox1.Text);
                    dataGridView1.DataSource = query.ToList();//将查询结果绑定到dataGridView1
                }
            }
        }

        //通用查询方法
        public IEnumerable<TSource> ConditionQuery<TSource>(IEnumerable<TSource> source, Func<TSource, bool> condition)
        {
            return source.Where(condition);
        }
    }
}
