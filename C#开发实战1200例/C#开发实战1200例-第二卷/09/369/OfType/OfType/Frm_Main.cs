using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OfType
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ArrayList arrList = new ArrayList(); //创建动态数组
            arrList.Add(1);//添加动态数组元素
            arrList.Add(2);
            arrList.Add("A");
            arrList.Add(3);
            arrList.Add("b");
            //使用LINQ筛选动态数组中是string类型的元素
            var query = from item in arrList.OfType<string>()
                        select item;
            label1.Text = "是字符串类型的有：";//显示string类型的元素
            foreach (var item in query)
            {
                label1.Text += item + " , ";
            }
        }
    }
}
