using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace AddDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private DateTime G_datetime;//定义时间字段
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            G_datetime=DateTime.Now;//得到系统当前时间
            lab_time.Text = G_datetime.ToString(//显示时间信息
                "时间：  yyyy年M月d日 H时m分s秒");
        }
        private void btn_AddM_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向时间字段中添加一分钟
                DateInterval.Minute, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//显示时间信息
                "时间：  yyyy年M月d日 H时m分s秒");
        }
        private void btn_AddH_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向时间字段中添加一小时
                DateInterval.Hour, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//显示时间信息
                "时间：  yyyy年M月d日 H时m分s秒");
        }
        private void btn_addD_Click(object sender, EventArgs e)
        {
            G_datetime = DateAndTime.DateAdd(//向时间字段中添加一天
              DateInterval.Day, 1, G_datetime);
            lab_time.Text = G_datetime.ToString(//显示时间信息
                "时间：  yyyy年M月d日 H时m分s秒");
        }
    }
}
