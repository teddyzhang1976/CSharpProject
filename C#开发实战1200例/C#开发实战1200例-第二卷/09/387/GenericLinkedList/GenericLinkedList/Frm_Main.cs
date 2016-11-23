using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericLinkedList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //构建泛型双向链表
            LinkedList<int> ints = new LinkedList<int>();
            ints.AddFirst(0);//添加第一个元素
            for (int i = 1; i < 10; i++)
            {
                ints.AddAfter(ints.Find(i - 1), i);//向泛型双向链表中添加元素
            }
            //LINQ过滤、排序泛型双向链表
            var query = from item in ints
                        where item > 0 && item < 9
                        orderby item descending
                        select item;
            //显示查询结果
            foreach (var item in query)
            {
                label1.Text += item.ToString() + "<=";
            }
        }
    }
}
