using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace TimeNow
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //变量用于存储年、月、日、时、分、秒
        public long LogYear, logMonth, logDay, logHour, logMinte, logSencon;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime get_time1 = DateTime.Now;//得到当前系统时间
            DateTime sta_ontime1 = Convert.ToDateTime(//得到世界杯开幕时间
                Convert.ToDateTime("2014-10-13 00:00:00"));
           txtYear.Text = DateAndTime.DateDiff(//计算相隔年数
               "yyyy", get_time1, sta_ontime1,
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           txtMonth.Text = DateAndTime.DateDiff(//计算相隔月数
               "m", get_time1, sta_ontime1, 
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           textday.Text = DateAndTime.DateDiff(//计算相隔天数
               "d", get_time1, sta_ontime1, 
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           txtHour.Text = DateAndTime.DateDiff(//计算相隔小时数
               "h", get_time1, sta_ontime1, 
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           txtmintue.Text = DateAndTime.DateDiff(//计算相隔分钟数
               "n", get_time1, sta_ontime1, 
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           txtsecon.Text = DateAndTime.DateDiff(//计算相隔秒数
               "s", get_time1, sta_ontime1, 
               FirstDayOfWeek.Sunday, 
               FirstWeekOfYear.FirstFourDays).ToString();
           textBox1.Text = DateTime.Now.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = //显示世界杯时间
                "2014-10-13  00:00:00" + "　　星期五";
            timer1.Enabled = true;//开启计时器
        }
    }
}