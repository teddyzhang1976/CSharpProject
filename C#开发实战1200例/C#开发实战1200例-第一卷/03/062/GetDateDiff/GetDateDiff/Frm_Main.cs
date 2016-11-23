using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GetDateDiff
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            MessageBox.Show("间隔 "+
                DateAndTime.DateDiff(//使用DateDiff方法获取日期间隔
                DateInterval.Day, dtpicker_first.Value, dtpicker_second.Value,
                FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString()+" 天", "间隔时间");
        }
    }
}
