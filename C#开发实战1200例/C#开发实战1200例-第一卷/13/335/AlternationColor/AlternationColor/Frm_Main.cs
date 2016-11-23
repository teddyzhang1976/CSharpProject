using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlternationColor
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//绑定数据集合
            new Fruit(){Name="苹果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鸭梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns[0].Width = 200;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
            dgv_Message.SelectionMode =//设置如何选中单元格
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Message.Rows.Count; i++)
            {

                if (i % 2 == 0)
                    dgv_Message.Rows[i].DefaultCellStyle.
                        BackColor = Color.LightYellow;//隔行更换背景色
            }
        }
    }
}
