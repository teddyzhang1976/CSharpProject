using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetInterval
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_DateTime_First,//定义两个时间字段
            G_DateTime_Second;
        private void btn_First_Click(object sender, EventArgs e)
        {
            G_DateTime_First = DateTime.Now;//为时间字段赋值
            lab_first.Text = "系统时间：" +//显示时间
                G_DateTime_First.ToString(
                "yyyy年M月d日 H时m分s秒 fff毫秒");
        }
        private void btn_Second_Click(object sender, EventArgs e)
        {
            G_DateTime_Second = DateTime.Now;//为时间字段赋值
            lab_second.Text = "系统时间：" +//显示时间
                G_DateTime_Second.ToString(
                "yyyy年M月d日 H时m分s秒 fff毫秒");
        }
        private void btn_Result_Click(object sender, EventArgs e)
        {
            TimeSpan P_timespan_temp =//计算两个时间的时间间隔
                G_DateTime_First > G_DateTime_Second ?
                G_DateTime_First - G_DateTime_Second :
                G_DateTime_Second - G_DateTime_First;
            lab_result.Text = string.Format(//显示时间间隔
                "间隔时间：{0}天{1}时{2}分{3}秒 {4}毫秒", 
                P_timespan_temp.Days, P_timespan_temp.Hours,
                P_timespan_temp.Minutes, P_timespan_temp.Seconds,
                P_timespan_temp.Milliseconds);
        }
    }
}
