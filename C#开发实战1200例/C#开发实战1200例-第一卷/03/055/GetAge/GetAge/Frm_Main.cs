using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GetAge
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetAge_Click(object sender, EventArgs e)
        {
            long P_BirthDay = DateAndTime.DateDiff(DateInterval.Year,//计算年龄
                 dtpicker_BirthDay.Value,DateTime.Now, 
                 FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
           MessageBox.Show(string.Format("年龄为： {0}岁。",//输出年龄信息
               P_BirthDay.ToString()),"提示！");
        }
    }
}
