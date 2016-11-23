using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CellValidate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Message.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)//验证指定列
            {
                float result = 0;//定义值类型变量并赋值
                if (!float.TryParse(//判断数据是否为数值类型
                    e.FormattedValue.ToString(), out result))
                {
                    dgv_Message.Rows[e.RowIndex].ErrorText =//提示错误信息
                        "内容必需为数值类型";
                    e.Cancel = true;//取消事件的值
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//绑定数据集合
            new Fruit(){Name="苹果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鸭梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31},
            new Fruit(){Name=""}};
            dgv_Message.Columns[0].Width = 200;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
            dgv_Message.Columns[0].DefaultCellStyle.Alignment =//设置对齐方式
                DataGridViewContentAlignment.MiddleCenter;
        }
      
    }
}