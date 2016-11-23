using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SumAndAverage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private List<Fruit> G_Fruit;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_Fruit = new List<Fruit>() {//创建集合并添加元素
            new Fruit(){Name="苹果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鸭梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns.Add("Fruit", "水果");//添加列
            dgv_Message.Columns.Add("Pric", "价格");//添加列
            foreach (Fruit f in G_Fruit)//添加元素
            {
                dgv_Message.Rows.Add(new string[] 
                { 
                    f.Name,
                    f.Price.ToString()
                });
            }
            dgv_Message.Columns[0].Width = 200;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
            float sum = 0;//定义float类型变量
            G_Fruit.ForEach(
                (pp) =>
                {
                    sum += pp.Price;//求和
                });
            dgv_Message.Rows.Add(new string[] //在新列中显示平均值及合计信息
            { 
                "合计： "+sum.ToString()+" 元",
                "平均价格： "+(sum/G_Fruit.Count).ToString()+" 元"
            });
        }
    }
}
