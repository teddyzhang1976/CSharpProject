using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhichWay
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (rbtn_school.Checked)//判断小明去学校还是去医院
            {
                MessageBox.Show("向左走","提示！");//如果去学校则向左走
            }
            else
            {
                MessageBox.Show("向右走", "提示！");//如果去医院则向右走
            }
        }
    }
}
