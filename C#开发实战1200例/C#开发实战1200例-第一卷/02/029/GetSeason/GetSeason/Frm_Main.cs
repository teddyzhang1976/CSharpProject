using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetSeason
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private void btn_true_Click(object sender, EventArgs e)
        {
            switch (//跟据所选月份判断季节
                cbox_select.SelectedIndex + 1)
            {
                case 3:
                case 4:
                case 5:
                    MessageBox.Show("春季", "提示！");
                    break;
                case 6:
                case 7:
                case 8:
                    MessageBox.Show("夏季", "提示！");
                    break;
                case 9:
                case 10:
                case 11:
                    MessageBox.Show("秋季", "提示！");
                    break;
                case 12:
                case 1:
                case 2:
                    MessageBox.Show("冬季", "提示！");
                    break;
                default://如果没有选择月份弹出提示信息
                    MessageBox.Show("请选择月份","提示！");
                    break;
            }
        }
    }
}
