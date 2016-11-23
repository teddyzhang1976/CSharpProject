using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntityRef
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
            var query = from it in dc.DictionaryItem
                        select new
                        {
                            it.DictItemID,
                            it.DictionaryType.DictTypeCode,//通过EntityRef<T>类型获取主表信息
                            it.DictionaryType.DictTypeName,
                            it.DictItemCode,
                            it.DictItemName
                        };
            dataGridView1.DataSource = query;//将查询的结果集绑定到dataGridView1
        }
    }
}
