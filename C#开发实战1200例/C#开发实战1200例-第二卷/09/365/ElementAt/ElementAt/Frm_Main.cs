using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElementAt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            List<int> ints = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = ints.ElementAt(3);//获取指定位置的元素
            //输出查询结果
            label1.Text = "数据源：ints={0,1,2,3,4,5,6,7,8,9 }";//数据源
            label2.Text = "查询表达式：ElementAt(3)";//查询表达式/操作
            label3.Text = "查询结果："+result.ToString();//查询结果
        }
    }
}
