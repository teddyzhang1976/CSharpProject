using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckBoxInDataGridView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private List<Fruit> P_Fruit;

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn dgvc =//创建列对象
                new DataGridViewCheckBoxColumn();
            dgvc.HeaderText = "状态";//设置列标题文本
            dgv_Message.Columns.Add(dgvc);//添加列
            P_Fruit = new List<Fruit>() {//创建数据集合
            new Fruit(){Name="苹果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鸭梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.DataSource = P_Fruit;//绑定数据集合
            dgv_Message.Columns[0].Width = 50;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
            dgv_Message.Columns[2].Width = 150;//设置列宽度

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Message.Rows.Count; i++)//遍历行集合
            {
                if (dgv_Message.Rows[i].Cells[0].Value != null &&
                    dgv_Message.Rows[i].Cells[1].Value != null &&
                    dgv_Message.Rows[i].Cells[2].Value != null )//判断值是否为空
                {
                    if (Convert.ToBoolean(dgv_Message.Rows[i].//判断是否选中项
                        Cells[0].Value.ToString()))
                    {
                        P_Fruit.RemoveAll(//标记集合中指定项
                            (pp) =>
                            {
                                if (pp.Name == dgv_Message.Rows[i].Cells[1].Value.ToString() &&
                                    pp.Price == Convert.ToSingle(
                                    dgv_Message.Rows[i].Cells[2].Value.ToString()))
                                    pp.ft = true;//开始标设
                                 return false;//不删除项
                            });
                    }
                }
            }
            P_Fruit.RemoveAll(//删除集合中指定项
                (pp) =>
                {
                    return pp.ft; 
                });
            dgv_Message.DataSource = null;//绑定为空
            dgv_Message.DataSource = P_Fruit;//绑定到数据集合
            dgv_Message.Columns[0].Width = 50;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
            dgv_Message.Columns[2].Width = 150;//设置列宽度
        }
    }
}
