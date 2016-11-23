using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridStyle
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.GridColor = Color.Blue;//设置网格颜色
            dgv_Message.DataSource = new List<Student>() {//绑定到数据集合
            new Student(){Name="小明",Age=30},
            new Student(){Name="老张",Age=40},
            new Student(){Name="小李",Age=33},
            new Student(){Name="云峰",Age=31}};
            dgv_Message.Columns[0].Width = 200;//设置列宽
            dgv_Message.Columns[1].Width = 170;//设置列宽
        }
    }
}
