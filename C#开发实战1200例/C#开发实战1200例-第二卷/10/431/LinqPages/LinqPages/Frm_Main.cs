using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqPages
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //创建LINQ对象
        LinqClassDataContext linqDataContext = new LinqClassDataContext();
        int pageSize = 7;//设置每页显示7条记录
        int page = 0;//记录当前页

        private void Form1_Load(object sender, EventArgs e)
        {
            page = 0;//设置当前页面
            bindGrid();//调用自定义bindGrid方法绑定DataGridView控件
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            page = 0;//设置当前页面为首页
            bindGrid();//调用自定义bindGrid方法绑定DataGridView控件
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            page = page - 1;//设置当前页数为当前页数减一
            bindGrid();//调用自定义bindGrid方法绑定DataGridView控件
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page = page + 1;//设置当前页数为当前页数加一
            bindGrid();//调用自定义bindGrid方法绑定DataGridView控件
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            page = getCount() - 1;//设置当前页数为总页面减一
            bindGrid();//调用自定义bindGrid方法绑定DataGridView控件
        }

        /// <summary>
        /// 对DataGridView控件进行数据绑定
        /// </summary>
        protected void bindGrid()
        {
            int pageIndex = Convert.ToInt32(page);//获取当前页数
            //使用LINQ查询，并对查询的数据进行分页
            var result = (from v in linqDataContext.Address
                          select new
                          {
                              地址编号 = v.AddressID,
                              城市 = v.City,
                              邮政编码 = v.PostalCode,
                              省份编号 = v.StateProvinceID
                          }).Skip(pageSize * pageIndex).Take(pageSize);
            dgvInfo.DataSource = result;//设置DataGridView控件的数据源
            btnEnd.Enabled =btnFirst.Enabled=btnBack.Enabled=btnNext.Enabled = true;
            //判断是否为第一页，如果为第一页，禁用首页和上一页按钮
            if (page == 0)
            {
                btnFirst.Enabled = btnBack.Enabled = false;
            }
            //判断是否为最后一页，如果为最后一页，禁用尾页和下一页按钮
            if (page == getCount() - 1)
            {
                btnEnd.Enabled = btnNext.Enabled = false;
            }
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns>返回得到的总页数</returns>
        protected int getCount()
        {
            int sum = linqDataContext.Address.Count();//设置总数据行数
            int s1 = sum / pageSize;//获取可以分的页面
            //当总行数对页数求余后是否大于0，如果大于获取1否则获取0
            int s2 = sum % pageSize > 0 ? 1 : 0;
            int count = s1 + s2;//计算出总页数
            return count;
        }
    }
}
