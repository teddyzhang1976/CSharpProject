using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetShengXiao
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            System.Globalization.ChineseLunisolarCalendar chinseCaleander =//创建日历对象
                 new System.Globalization.ChineseLunisolarCalendar();
            string TreeYear = "鼠牛虎兔龙蛇马羊猴鸡狗猪";//创建字符串对象
            int intYear = chinseCaleander.GetSexagenaryYear(DateTime.Now);//计算年信息
            string Tree = TreeYear.Substring(chinseCaleander.//得到生肖信息
                GetTerrestrialBranch(intYear) - 1, 1);
            MessageBox.Show("今年是十二生肖" + Tree + "年",//输出生肖信息
                "判断十二生肖", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}