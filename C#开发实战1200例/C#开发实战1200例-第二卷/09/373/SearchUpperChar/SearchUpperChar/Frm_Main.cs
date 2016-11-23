using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchUpperChar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string sourceString = "int I = 5; string S = (I % 2 == 0 ? \"偶数\" : \"奇数\");";
            //过滤字符串中所有的大写字符
            var query = from s in sourceString
                        where char.IsUpper(s)
                        select s;
            //显示查询结果
            label1.Text = "数据源：" + sourceString + "\n\n";
            label1.Text += "属于大写字母类别的字符有：";
            foreach (var item in query)
            {
                label1.Text += item.ToString() + "  ";
            }
        }
    }
}
