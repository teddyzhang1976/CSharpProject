using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DragViewTerm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //起动拖放放操作，设置拖放类型
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }
        //选择要拖动的项
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            //获取ListView类型数据
            for (int i = 0; i <= e.Data.GetFormats().Length - 1; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            //判断是否选择拖放的项
            if (listView1.SelectedItems.Count == 0)
            {
                return;//退出方法
            }
            Point cp = listView1.PointToClient(new Point(e.X, e.Y));//定义项的坐标点
            ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);//得到指定位置的项

            if (dragToItem == null)//判断是否为空
            {
                return;//退出方法
            }
            List<ListViewItem> ls = new List<ListViewItem>();//创建项集合
            foreach (ListViewItem lvi in listView1.SelectedItems)//遍历选中的项
            {
                ls.Add(lvi);//将选中项添加到集合
            }
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Remove(ls[i]);
            }
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Insert(dragToItem.Index, ls[i]);
            }
            ls.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ls.Add(listView1.Items[i]);
            }
            listView1.Items.Clear();
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Add(ls[i]);
            }
        }
    }
}