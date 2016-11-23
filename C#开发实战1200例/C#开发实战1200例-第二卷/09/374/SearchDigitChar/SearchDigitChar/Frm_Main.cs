using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchDigitChar
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string sourceString = "int I = 5; string S = (I % 2 == 0 ? \"偶数\" : \"奇数\");";//声明字符串
            //过滤字符串中所有的十进制数字类别的字符
            var query = from s in sourceString
                        where char.IsDigit(s)
                        select s;
            //显示查询结果
            label1.Text = sourceString + "\n\n";
            label1.Text += "属于十进制数字类别的字符有：";
            foreach (var item in query)
            {
                label1.Text += item.ToString() + "  ";
            }
        }
    }
}
